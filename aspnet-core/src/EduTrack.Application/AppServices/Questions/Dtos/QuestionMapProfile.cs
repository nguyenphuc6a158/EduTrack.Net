using AutoMapper;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class QuestionMapProfile : Profile
    {
        public QuestionMapProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<CreateQuestionDto, Question>();
        }
    }
}
