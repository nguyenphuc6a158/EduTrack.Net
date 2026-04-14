using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.StudenClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EduTrack.AppServices.Assignments
{
    [AbpAuthorize]
    public class AssignmentAppService
    : AsyncCrudAppService<Assignment, AssignmentDto, long, PagedAssignmentResultRequestDto, CreateAssignmentDto, UpdateAssignmentDto>,
      IAssignmentAppService
    {
        private readonly IRepository<AssignmentQuestion, long> _assignmentQuestionRepository;
        private readonly IRepository<Chapter, long> _chapterRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<ClassAssignment, long> _classAssignmentRepository;
        private readonly IRepository<StudentClass, long> _studentClassRepository;

        public AssignmentAppService(
            IRepository<Assignment, long> repository,
            IRepository<AssignmentQuestion, long> assignmentQuestionRepository,
            IRepository<User, long> userRepository,
            IRepository<Chapter, long> chapterRepository,
            IRepository<ClassAssignment, long> classAssignmentRepository,
            IRepository<StudentClass, long> studentClassRepository

        ) : base(repository)
        {
            _classAssignmentRepository = classAssignmentRepository;
            _studentClassRepository = studentClassRepository;
            _assignmentQuestionRepository = assignmentQuestionRepository;
            _userRepository = userRepository;
            _chapterRepository = chapterRepository;
            GetPermissionName = PermissionNames.Pages_Assignments;
            GetAllPermissionName = PermissionNames.Pages_Assignments;

            CreatePermissionName = PermissionNames.Pages_Assignments_Create;
            UpdatePermissionName = PermissionNames.Pages_Assignments_Update;
            DeletePermissionName = PermissionNames.Pages_Assignments_Delete;
        }
        public async Task CreateAssignmentWithQuestionsAsync(CreateAssignmentWithQuestionsDto input)
        {
            var assignment = ObjectMapper.Map<Assignment>(input);

            await Repository.InsertAsync(assignment);
            await CurrentUnitOfWork.SaveChangesAsync();

            var assignmentQuestions = input.assignmentQuestions.Select(q => new AssignmentQuestion
            {
                QuestionId = q.QuestionId,
                AssignmentId = assignment.Id,
                OrderIndex = q.OrderIndex,
            }).ToList();

            foreach (var item in assignmentQuestions)
            {
               await _assignmentQuestionRepository.InsertAsync(item);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAssignmentWithQuestionsAsync(UpdateAssignmentWithQuestionsDto input)
        {
            var assignment = await Repository.GetAsync(input.Id);

            assignment.ChapterId = input.chapterId;
            assignment.Title = input.title;
            await Repository.UpdateAsync(assignment);
            await CurrentUnitOfWork.SaveChangesAsync();

            await _assignmentQuestionRepository.DeleteAsync(aq => aq.AssignmentId == assignment.Id);
            var assignmentQuestions = input.assignmentQuestions.Select(q => new AssignmentQuestion
            {
                QuestionId = q.QuestionId,
                AssignmentId = assignment.Id,
                OrderIndex = q.OrderIndex,
            }).ToList();

            foreach (var item in assignmentQuestions)
            {
                await _assignmentQuestionRepository.InsertAsync(item);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(EntityDto<long> input)
        {
            await Repository.DeleteAsync(input.Id);
            await _assignmentQuestionRepository.DeleteAsync(aq => aq.AssignmentId == input.Id);
        }
        public override async Task<PagedResultDto<AssignmentDto>> GetAllAsync(PagedAssignmentResultRequestDto input)
        {
            var query = Repository.GetAll();

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            var assignments = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );

            var ChapterIds = assignments.Select(x => x.ChapterId).Distinct().ToList();
            var chapters = await _chapterRepository.GetAll().Where(c => ChapterIds.Contains(c.Id)).ToListAsync();
            var userIds = assignments.Select(x => x.CreatorUserId).Distinct().ToList();
            var users = await _userRepository.GetAll().Where(u => userIds.Contains(u.Id)).ToListAsync();
            var result = assignments.Select(a =>
            {
                var chapter = chapters.FirstOrDefault(c => c.Id == a.ChapterId);
                var user = users.FirstOrDefault(u => u.Id == a.CreatorUserId);
                return new AssignmentDto
                {
                    Id = a.Id,
                    ChapterId = a.ChapterId,
                    Title = a.Title,
                    ChapterName = chapter.ChapterName,
                    CreateBy = user.FullName
                };
            }).ToList();
            return new PagedResultDto<AssignmentDto>(totalCount, result);
        }
        public async Task<PagedResultDto<AssignmentDto>> GetAllAssignmentForStudentAsync(long userId, long chapterId, PagedAssignmentResultRequestDto input)
        {
            var studentClass = await _studentClassRepository.FirstOrDefaultAsync(x => x.StudentId == userId && x.ClassId == chapterId);
            if (studentClass == null)
            {
                throw new UserFriendlyException("Sinh viên không thuộc lớp này");
            }
            var classId = studentClass.ClassId;
            var classAssignments = await _classAssignmentRepository.GetAll().Where(ca => ca.ClassId == classId && ca.PublicTime <= Clock.Now).ToListAsync();
            var assignmentIds = classAssignments.Select(ca => ca.AssignmentId).ToList();
            var query = Repository.GetAll().Where(a => assignmentIds.Contains(a.Id));
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var assignments = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );

            var chapterIds = assignments.Select(a => a.ChapterId).Distinct().ToList();
            var chapters = await _chapterRepository.GetAll().Where(c => chapterIds.Contains(c.Id)).ToListAsync();
            var userIds = assignments.Select(x => x.CreatorUserId).Distinct().ToList();
            var users = await _userRepository.GetAll().Where(u => userIds.Contains(u.Id)).ToListAsync();

            var result = assignments.Select(a =>
            {
                var chapter = chapters.FirstOrDefault(c => c.Id == a.ChapterId);
                var user = users.FirstOrDefault(u => u.Id == a.CreatorUserId);
                return new AssignmentDto
                {
                    Id = a.Id,
                    ChapterId = a.ChapterId,
                    Title = a.Title,
                    ChapterName = chapter?.ChapterName,
                    CreateBy = user?.FullName
                };
            }).ToList();

            return new PagedResultDto<AssignmentDto>(totalCount, result);
        }
    }
}
