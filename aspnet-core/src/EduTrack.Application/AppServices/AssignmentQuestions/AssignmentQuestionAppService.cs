using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.AssignmentQuestions.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions
{
    [AbpAuthorize]
    public class AssignmentQuestionAppService : AsyncCrudAppService<AssignmentQuestion, AssignmentQuestionDto, long, PagedAssignmentQuestionResulRequestDto, CreateAssignmentQuestionDto, UpdateAssignmentQuestionDto>, IAssignmentQuestionAppService
    {
        public AssignmentQuestionAppService(IRepository<AssignmentQuestion, long> repository)
            : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_AssignmentQuestions;
            GetAllPermissionName = PermissionNames.Pages_AssignmentQuestions;

            CreatePermissionName = PermissionNames.Pages_AssignmentQuestions_Create;
            UpdatePermissionName = PermissionNames.Pages_AssignmentQuestions_Update;
            DeletePermissionName = PermissionNames.Pages_AssignmentQuestions_Delete;
        }
    }
}
