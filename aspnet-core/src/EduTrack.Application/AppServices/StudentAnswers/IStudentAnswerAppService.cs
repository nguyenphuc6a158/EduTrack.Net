using Abp.Application.Services;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAnswers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAnswers
{
    public interface IStudentAnswerAppService
    : IAsyncCrudAppService<
        StudentAnswerDto,
        long,
        PagedStudentAnswerResultRequestDto,
        CreateStudentAnswerDto,
        UpdateStudentAnswerDto>
    {
    }
}
