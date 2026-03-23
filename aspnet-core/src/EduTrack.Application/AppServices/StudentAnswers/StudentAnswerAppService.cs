using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAnswers.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAnswers
{
    public class StudentAnswerAppService
    : AsyncCrudAppService<StudentAnswer, StudentAnswerDto, long, PagedStudentAnswerResultRequestDto, CreateStudentAnswerDto, UpdateStudentAnswerDto>,
      IStudentAnswerAppService
    {
        public StudentAnswerAppService(IRepository<StudentAnswer, long> repository)
            : base(repository)
        {
        }
    }
}
