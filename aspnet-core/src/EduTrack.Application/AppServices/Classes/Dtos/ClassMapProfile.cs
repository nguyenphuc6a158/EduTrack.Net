using AutoMapper;
using EduTrack.Entity.Classes;

namespace EduTrack.AppServices.Classes.Dtos;

public class StudentClassMapProfile : Profile
{
    public StudentClassMapProfile()
    {
        CreateMap<Class, ClassDto>();
        CreateMap<CreateClassDto, Class>();
    }
}