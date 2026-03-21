using AutoMapper;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.Entities.StudenClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Subjects.Dto
{
    public class SubjectMapProfile : Profile
    {
        public SubjectMapProfile()
        {
            CreateMap<StudentClass, SubjectDto>();
            CreateMap<CreateSubjectDto, StudentClass>();
        }
    }
}
