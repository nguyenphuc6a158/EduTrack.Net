using AutoMapper;
using EduTrack.Entities.Questions;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class QuestionMapProfile : Profile
    {
        public QuestionMapProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<CreateQuestionDto, Question>();
            CreateMap<CreateQuestionWithOptionsDto, Question>();
            CreateMap<UpdateQuestionWithOptionsDto, Question>();
            CreateMap<UpdateQuestionDto, Question>();
        }
    }
}
