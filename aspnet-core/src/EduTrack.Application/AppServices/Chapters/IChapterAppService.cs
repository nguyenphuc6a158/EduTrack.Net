using Abp.Application.Services;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.Classes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Chapters
{
    public interface IChapterAppService : IAsyncCrudAppService<ChapterDto, long, PagedChapterResultRequestDto, CreateChapterDto, UpdateChapterDto>
    {
    }
}
