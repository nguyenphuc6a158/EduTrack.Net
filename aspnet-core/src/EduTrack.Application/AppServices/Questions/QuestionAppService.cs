using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.Questions;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions
{
    [AbpAuthorize]
    public class QuestionAppService
    : AsyncCrudAppService<Question, QuestionDto, long, PagedQuestionResultRequestDto, CreateQuestionDto, UpdateQuestionDto>,
      IQuestionAppService
    {
        public QuestionAppService(IRepository<Question, long> repository)
            : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_Questions;
            GetAllPermissionName = PermissionNames.Pages_Questions;

            CreatePermissionName = PermissionNames.Pages_Questions_Create;
            UpdatePermissionName = PermissionNames.Pages_Questions_Update;
            DeletePermissionName = PermissionNames.Pages_Questions_Delete;
        }
    }
}
