using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions
{
    public class QuestionAppService
    : AsyncCrudAppService<Question, QuestionDto, long, PagedQuestionResultRequestDto, CreateQuestionDto, UpdateQuestionDto>,
      IQuestionAppService
    {
        public QuestionAppService(IRepository<Question, long> repository)
            : base(repository)
        {
        }
    }
}
