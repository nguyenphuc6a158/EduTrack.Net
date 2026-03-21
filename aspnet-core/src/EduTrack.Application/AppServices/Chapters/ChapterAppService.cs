using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.Entities.Chapters;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Chapters
{
    public class ChapterAppService
    : AsyncCrudAppService<Chapter, ChapterDto, long, PagedChapterResultRequestDto, CreateChapterDto, UpdateChapterDto>,
      IChapterAppService
    {
        public ChapterAppService(IRepository<Chapter, long> repository)
            : base(repository)
        {
        }
    }
}
