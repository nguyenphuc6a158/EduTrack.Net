using AutoMapper;
using EduTrack.Entities.StudenClasses;

namespace EduTrack.AppServices.StudentClasses.Dtos;

public class StudentClassMapProfile : Profile
{
    public StudentClassMapProfile()
    {
        CreateMap<StudentClass, StudentClassDto>();
        CreateMap<CreateStudentClassDto, StudentClass>();
        CreateMap<UpdateStudentClassDto, StudentClass>();
    }
}