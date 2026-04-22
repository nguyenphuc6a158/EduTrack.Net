using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.AssignmentQuestions.Dtos;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.StudenClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions
{
    [AbpAuthorize]
    public class AssignmentQuestionAppService : AsyncCrudAppService<AssignmentQuestion, AssignmentQuestionDto, long, PagedAssignmentQuestionResulRequestDto, CreateAssignmentQuestionDto, UpdateAssignmentQuestionDto>, IAssignmentQuestionAppService
    {
        private readonly IRepository<StudentClass, long> _studentClassRepository;
        private readonly IRepository<ClassAssignment, long> _classAssignmentRepository;
        public AssignmentQuestionAppService(
            IRepository<AssignmentQuestion, long> repository,
            IRepository<StudentClass, long> studentClassRepository,
            IRepository<ClassAssignment, long> classAssignmentRepository
        ) : base(repository)
        {
            _studentClassRepository = studentClassRepository;
            _classAssignmentRepository = classAssignmentRepository;

            GetPermissionName = PermissionNames.Pages_AssignmentQuestions;
            GetAllPermissionName = PermissionNames.Pages_AssignmentQuestions;

            CreatePermissionName = PermissionNames.Pages_AssignmentQuestions_Create;
            UpdatePermissionName = PermissionNames.Pages_AssignmentQuestions_Update;
            DeletePermissionName = PermissionNames.Pages_AssignmentQuestions_Delete;
        }
        public async Task<PagedResultDto<AssignmentQuestionDto>> GetAllAssignmentQuestionByAssignmentIdAsync(long assignmentId, long userId, PagedAssignmentQuestionResulRequestDto input)
        {
            var studentClass = _studentClassRepository.GetAll().Where(c => c.StudentId == userId);
            if (studentClass == null)
            {
                return new PagedResultDto<AssignmentQuestionDto>(0, new List<AssignmentQuestionDto>());
            }

            var classIds = studentClass.Select(c => c.ClassId);
            var hasAssignmentForClass = _classAssignmentRepository.GetAll()
                .Any(ca => ca.AssignmentId == assignmentId && classIds.Contains(ca.ClassId));

            if (!hasAssignmentForClass)
            {
                return new PagedResultDto<AssignmentQuestionDto>(0, new List<AssignmentQuestionDto>());
            }
            var query = Repository.GetAll().Where(x => x.AssignmentId == assignmentId);

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x => x.Question != null &&
                                         (x.Question.FileUrlAssignment.Contains(input.Keyword) ||
                                          (x.Question.FileUrlExplain != null && x.Question.FileUrlExplain.Contains(input.Keyword))));
            }
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            // Apply sorting (dynamic) and paging
            //if (!string.IsNullOrWhiteSpace(input.Sorting))
            //{
            //    query = query.OrderBy(input.Sorting);
            //}
            query = query.OrderBy(q => q.OrderIndex);

            query = query.Skip(input.SkipCount).Take(input.MaxResultCount);

            var assignmentQuestions = await AsyncQueryableExecuter.ToListAsync(query);
            var result = ObjectMapper.Map<List<AssignmentQuestionDto>>(assignmentQuestions);

            return new PagedResultDto<AssignmentQuestionDto>(totalCount, result);
        }

    }
}
