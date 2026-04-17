using AutoMapper;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments.Dtos
{
    public class AssignmentMapProfile : Profile
    {
        public AssignmentMapProfile()
        {
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<Assignment, DetailAssignmentForStudentDto>();
            CreateMap<CreateAssignmentDto, Assignment>();
            CreateMap<CreateAssignmentWithQuestionsDto, Assignment>();
            CreateMap<UpdateAssignmentWithQuestionsDto, Assignment>();
            CreateMap<UpdateAssignmentDto, Assignment>();
        }
    }
}
