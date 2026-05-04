using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Timing;
using Abp.UI;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAnswers.Dtos;
using EduTrack.AppServices.StudentAssignments.Dtos;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.StudentAssignments;
using EduTrack.Entity.Classes;
using EduTrack.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EduTrack.AppServices.StudentAssignments
{
    public class StudentAssignmentAppService
    : AsyncCrudAppService<StudentAssignment, StudentAssignmentDto, long, PagedStudentAssignmentResultRequestDto, CreateStudentAssignmentInput, UpdateStudentAssignmentInput>,
      IStudentAssignmentAppService
    {
        private readonly IRepository<StudentClass, long> _studentClassRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<ClassAssignment, long> _classAssignmentsRepository;
        public StudentAssignmentAppService(
            IRepository<StudentAssignment, long> repository,
            IRepository<StudentClass, long> studentClassRepository,
            IRepository<User, long> userRepository,
            IRepository<ClassAssignment, long> classAssignmentsRepository
        ) : base(repository)
        {
            _studentClassRepository = studentClassRepository;
            _userRepository = userRepository;
            _classAssignmentsRepository = classAssignmentsRepository;
        }
        public async Task<StudentAssignmentDto> GetStudentAssignmentByStudentIDAndAssignmentId(long studentId, long assignmentId)
        {
            var entity = await Repository.GetAll().FirstOrDefaultAsync(x => x.StudentId == studentId && x.AssignmentId == assignmentId);
            return ObjectMapper.Map<StudentAssignmentDto>(entity);
        }
        public async Task<List<StudentAssignmentDto>> CreateListStudentAssignmentByListClass(CreateListStudentAssignmentByListClassInput input)
        {
            var classIds = input.ListClasses.Select(c => c.Id).ToList();
            var studentIds = _studentClassRepository.GetAll()
                                .Where(sc => classIds.Contains(sc.ClassId))
                                .Select(sc => sc.StudentId)
                                .Distinct()
                                .ToList();
            var students = _userRepository.GetAll()
                                .Where(u => studentIds.Contains(u.Id))
                                .ToList();
            var existedStudentIds = Repository.GetAll()
                                              .Where(x => x.AssignmentId == input.AssignmentId)
                                              .Select(x => x.StudentId)
                                              .ToList();
            var studentAssignments = new List<StudentAssignment>();
            foreach (var student in students) {
                if (existedStudentIds.Contains(student.Id))
                    continue;
                var studentAssignment = new StudentAssignment();
                studentAssignment.StudentId = student.Id;
                studentAssignment.AssignmentId = input.AssignmentId;
                studentAssignment.Status = (int)Status.NOTSTARTED;
                studentAssignment.Score = 0;
                studentAssignment.TotalCorrect = 0;
                studentAssignment.TotalQuestions = input.TotalQuestions;
                studentAssignment.SubmittedAt = input.SubmittedAt;

                studentAssignments.Add(studentAssignment);
            }
            await Repository.InsertRangeAsync(studentAssignments);
            return ObjectMapper.Map<List<StudentAssignmentDto>>(studentAssignments);
        }
        public async override Task<StudentAssignmentDto> UpdateAsync(UpdateStudentAssignmentInput input)
        {
            var entity = await Repository.GetAll()
                .FirstOrDefaultAsync(x => x.StudentId == input.StudentId && x.AssignmentId == input.AssignmentId);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(StudentAssignment), input.Id);
            }

            entity.Status = input.Status;
            entity.Score = input.Score;
            entity.TotalCorrect = input.TotalCorrect;
            entity.TotalQuestions = input.TotalQuestions;
            entity.SubmittedAt = input.SubmittedAt;

            await Repository.UpdateAsync(entity);

            return ObjectMapper.Map<StudentAssignmentDto>(entity);
        }
        public async Task<DatailDoHomeWorkDto> GetDetailDoHomeWorkDto(long userId)
        {
            var classId = _studentClassRepository.GetAll().Where(sc => sc.StudentId == userId)
                .Select(sc => sc.ClassId)
                .FirstOrDefault();
            var query = from sa in Repository.GetAll()
                       join ca in _classAssignmentsRepository.GetAll()
                       on sa.AssignmentId equals ca.AssignmentId 
                        where sa.StudentId == userId && ca.ClassId == classId
                       select new
                       {
                           Status = sa.Status,
                           Score = sa.Score,
                           PublicTime = ca.PublicTime
                       };
            var data = await AsyncQueryableExecuter.ToListAsync(query);
            if (!data.Any())
            {
                return null;
            }
            var now = Clock.Now;
            
            var startCurrentMonth = new DateTime(now.Year, now.Month, 1);
            var endCurrentMonth = startCurrentMonth.AddMonths(1).AddDays(-1);

            var startPreviousMonth = startCurrentMonth.AddMonths(-1);
            var endPreviousMonth = startCurrentMonth.AddDays(-1);

            var avgScoreCurrentMonth = data.Where(x => x.PublicTime >= startCurrentMonth && x.PublicTime <= endCurrentMonth)
                .Select(x => x.Score)
                .DefaultIfEmpty(0)
                .Average();
            var avgScorePreviousMonth = data.Where(x => x.PublicTime >= startPreviousMonth && x.PublicTime <= endPreviousMonth)
                .Select(x => x.Score)
                .DefaultIfEmpty(0)
                .Average();
            var total = data.Count;
            var statusesCurrentMonth = data
                .Where(x => x.PublicTime >= startCurrentMonth &&
                            x.PublicTime < endCurrentMonth)
                .Select(x => x.Status);
            

            var totalCompletedCurrentMonth = statusesCurrentMonth
                .Count(status => status == (int)Status.COMPLATED);
            var totalCurrentMonth = statusesCurrentMonth.Count();

            var statusesPreviousMonth = data
                .Where(x => x.PublicTime >= startPreviousMonth &&
                            x.PublicTime < endPreviousMonth)
                .Select(x => x.Status);
            var totalCompletedPreviousMonth = statusesPreviousMonth
                .Count(status => status == (int)Status.COMPLATED);
            var totalPreviousMonth = statusesPreviousMonth.Count();

            var totalCompleted = data.Count(x => x.Status == (int)Status.COMPLATED);
            var totalNotStarted = data.Count(x => x.Status == (int)Status.NOTSTARTED);
            var totalInProgress = total - totalCompleted - totalNotStarted;

            var avgScore = data.Select(x => x.Score).DefaultIfEmpty(0).Average();

            return new DatailDoHomeWorkDto
            {
                Series = new List<int>
                {
                    totalCompleted,
                    totalInProgress,
                    totalNotStarted
                },
                AvgScore = avgScore,
                AvgScoreImprovement = avgScoreCurrentMonth - avgScorePreviousMonth,
                AvgScoreCurrentMonth = avgScoreCurrentMonth,
                CompletedCurrentMonthRate = (totalCompletedCurrentMonth / totalCurrentMonth) * 100,
                CompletedPreviousMonthRate = (totalCompletedPreviousMonth / totalPreviousMonth) * 100
            };
        }
    }
}
