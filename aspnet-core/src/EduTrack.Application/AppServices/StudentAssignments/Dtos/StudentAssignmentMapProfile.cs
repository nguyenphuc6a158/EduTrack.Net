using AutoMapper;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments.Dtos
{
    public class StudentAssignmentMapProfile : Profile
    {
        public StudentAssignmentMapProfile()
        {
            CreateMap<StudentAssignment, StudentAssignmentDto>();
            CreateMap<CreateStudentAssignmentInput, StudentAssignment>();
            CreateMap<UpdateStudentAssignmentInput, StudentAssignment>();
        }
    }
}
