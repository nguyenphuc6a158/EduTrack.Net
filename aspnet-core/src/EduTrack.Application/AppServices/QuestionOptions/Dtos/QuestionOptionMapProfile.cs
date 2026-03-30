using AutoMapper;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions.Dtos
{
    public class QuestionOptionMapProfile : Profile
    {
        public QuestionOptionMapProfile()
        {
            CreateMap<QuestionOption, QuestionOptionDto>();
            CreateMap<CreateQuestionOptionDto, QuestionOption>();
            CreateMap<UpdateQuestionOptionDto, QuestionOption>();
        }
    }
}
