using AutoMapper;
using EduTrack.Classes;
using EduTrack.Classes.Dtos;

namespace EduTrack.Students;

public class ClassMapProfile : Profile
{
    public ClassMapProfile()
    {
        CreateMap<Class, ClassDto>();
        CreateMap<CreateClassDto, Class>();
    }
}