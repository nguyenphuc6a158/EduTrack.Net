using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.Chapters;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Chapters
{
    [AbpAuthorize]
    public class ChapterAppService
    : AsyncCrudAppService<Chapter, ChapterDto, long, PagedChapterResultRequestDto, CreateChapterDto, UpdateChapterDto>,
      IChapterAppService
    {
        public ChapterAppService(IRepository<Chapter, long> repository)
            : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_Chapters;
            GetAllPermissionName = PermissionNames.Pages_Chapters;

            CreatePermissionName = PermissionNames.Pages_Chapters_Create;
            UpdatePermissionName = PermissionNames.Pages_Chapters_Update;
            DeletePermissionName = PermissionNames.Pages_Chapters_Delete;
        }
    }
}
