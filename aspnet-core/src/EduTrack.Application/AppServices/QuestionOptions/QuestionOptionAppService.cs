using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.QuestionOptions.Dtos;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions
{
    internal class QuestionOptionAppService
    {
    }
    public class QuestionOptionAppServiceQuestionAppService
    : AsyncCrudAppService<QuestionOption, QuestionOptionDto, long, PagedQuestionOptionResultRequestDto, CreateQuestionOptionDto, UpdateQuestionOptionDto>,
      IQuestionOptionAppService
    {
        public QuestionOptionAppServiceQuestionAppService(IRepository<QuestionOption, long> repository)
            : base(repository)
        {
        }
    }
}
