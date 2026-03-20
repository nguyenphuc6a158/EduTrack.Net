using AutoMapper;
using EduTrack.Entity.Classes;

namespace EduTrack.AppServices.Classes.Dtos;

public class ClassMapProfile : Profile
{
    public ClassMapProfile()
    {
        CreateMap<Class, ClassDto>();
        CreateMap<CreateClassDto, Class>();
    }
}