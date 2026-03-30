using AutoMapper;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.StudentProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentProsesses.Dtos
{
    public class StudentProgressMapProfile : Profile
    {
        public StudentProgressMapProfile()
        {
            CreateMap<StudentProgress, StudentProgressDto>();
            CreateMap<CreateStudentProgressDto, StudentProgress>();
            CreateMap<UpdateStudentProgressDto, StudentProgress>();
        }
    }
}
