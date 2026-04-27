using AutoMapper;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAnswers.Dtos
{
    public class StudentAnswerMapProfile : Profile
    {
        public StudentAnswerMapProfile()
        {
            CreateMap<StudentAnswer, StudentAnswerDto>();
            CreateMap<CreateStudentAnswerInput, StudentAnswer>();
            CreateMap<UpdateStudentAnswerInput, StudentAnswer>();
        }
    }
}
