using AutoMapper;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions.Dtos
{
    public class AssignmentQuestionMapProfile : Profile
    {
        public AssignmentQuestionMapProfile()
        {
            CreateMap<AssignmentQuestion, AssignmentQuestionDto>();
            CreateMap<CreateAssignmentQuestionDto, AssignmentQuestion>();
            CreateMap<UpdateAssignmentQuestionDto, AssignmentQuestion>();
        }
    }
}
