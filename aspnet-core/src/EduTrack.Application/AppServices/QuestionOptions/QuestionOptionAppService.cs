using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.AppServices.QuestionOptions.Dtos;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions
{
    [AbpAuthorize]
    public class QuestionOptionAppService
    : AsyncCrudAppService<QuestionOption, QuestionOptionDto, long, PagedQuestionOptionResultRequestDto, CreateQuestionOptionDto, UpdateQuestionOptionDto>,
      IQuestionOptionAppService
    {
        public QuestionOptionAppService(IRepository<QuestionOption, long> repository)
            : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_QuestionOptions;
            GetAllPermissionName = PermissionNames.Pages_QuestionOptions;

            CreatePermissionName = PermissionNames.Pages_QuestionOptions_Create;
            UpdatePermissionName = PermissionNames.Pages_QuestionOptions_Update;
            DeletePermissionName = PermissionNames.Pages_QuestionOptions_Delete;
        }
    }
}
