using Abp.Application.Services;
using EduTrack.AppServices.QuestionOptions.Dtos;
using EduTrack.AppServices.Questions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions
{
    public interface IQuestionOptionAppService
    : IAsyncCrudAppService<
        QuestionOptionDto,
        long,
        PagedQuestionOptionResultRequestDto,
        CreateQuestionOptionDto,
        UpdateQuestionOptionDto>
    {
    }
}
