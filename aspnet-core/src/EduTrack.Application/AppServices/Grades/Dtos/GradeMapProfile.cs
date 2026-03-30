using AutoMapper;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Grades.Dtos
{
    public class GradeMapProfile : Profile
    {
        public GradeMapProfile()
        {
            CreateMap<Grade, GradeDto>();
            CreateMap<CreateGradeDto, Grade>();
            CreateMap<UpdateGradeDto, Grade>();
        }
    }
}
