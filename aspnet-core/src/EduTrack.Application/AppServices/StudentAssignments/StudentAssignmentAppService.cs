using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAssignments.Dtos;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.StudentAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments
{
    public class StudentAssignmentAppService
    : AsyncCrudAppService<StudentAssignment, StudentAssignmentDto, long, PagedStudentAssignmentResultRequestDto, CreateStudentAssignmentDto, UpdateStudentAssignmentDto>,
      IStudentAssignmentAppService
    {
        private readonly IRepository<StudentClass, long> _studentClassRepository;
        private readonly IRepository<ClassAssignment, long> _classAssignmentRepository;
        public StudentAssignmentAppService(
            IRepository<StudentAssignment, long> repository,
            IRepository<StudentClass, long> studentClassRepository,
            IRepository<ClassAssignment, long> classAssignmentRepository
        ) : base(repository)
        {
            _studentClassRepository = studentClassRepository;
        }
        public async override Task<StudentAssignmentDto> CreateAsync(CreateStudentAssignmentDto input)
        {
            if (await CheckExist(input.StudentId, input.AssignmentId))
            {
                throw new UserFriendlyException("A student assignment for this student and assignment already exists.");
            }

            if (input.SubmittedAt == default)
            {
                input.SubmittedAt = Clock.Now;
            }

            return await base.CreateAsync(input);
        }
        public async Task<bool> CheckExist(long studentId, long assignmentId) 
        {
            var query = Repository.GetAll().Where(x => x.StudentId == studentId && x.AssignmentId == assignmentId);
            var existed = await AsyncQueryableExecuter.AnyAsync(query);
            return existed;
        }
    }
    
}
