using AutoMapper;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.Entities.Chapters;
using EduTrack.Entity.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Chapters.Dtos
{
    public class ChapterMapProfile : Profile
    {
        public ChapterMapProfile()
        {
            CreateMap<Chapter, ChapterDto>();
            CreateMap<CreateChapterDto, Chapter>();
            CreateMap<UpdateChapterDto, Chapter>();
        }
    }
}
