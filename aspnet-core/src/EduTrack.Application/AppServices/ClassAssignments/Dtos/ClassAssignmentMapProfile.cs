using AutoMapper;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments.Dtos
{
    public class ClassAssignmentMapProfile : Profile
    {
        public ClassAssignmentMapProfile()
        {
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<CreateAssignmentDto, Assignment>();
            CreateMap<UpdateAssignmentDto, Assignment>();
        }
    }
}
