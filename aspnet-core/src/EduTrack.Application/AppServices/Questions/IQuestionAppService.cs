using Abp.Application.Services;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.AppServices.Questions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions
{
    public interface IQuestionAppService
    : IAsyncCrudAppService<
        QuestionDto,
        long,
        PagedQuestionResultRequestDto,
        CreateQuestionDto,
        UpdateQuestionDto>
    {
    }
}
