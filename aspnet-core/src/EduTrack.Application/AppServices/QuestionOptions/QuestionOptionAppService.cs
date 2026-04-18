using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.AppServices.QuestionOptions.Dtos;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.Chapters;
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
        public async Task<PagedResultDto<QuestionOptionDto>> GetAllByQuestionIdAsync(long questionId, PagedQuestionOptionResultRequestDto input)
        {
            var query = Repository.GetAll().Where(qo => qo.QuestionId == questionId);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var questionOptions = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );
            var result = questionOptions.Select(q =>
            {

                return new QuestionOptionDto
                {
                    Id = q.Id,
                    Content = q.Content
                };
            }).ToList();
            return new PagedResultDto<QuestionOptionDto>(
                totalCount,
                result
            );
        }
    }
}
