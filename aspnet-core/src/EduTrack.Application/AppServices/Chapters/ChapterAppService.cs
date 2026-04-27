using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.Chapters;
using EduTrack.Entity.Grades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //GetPermissionName = PermissionNames.Pages_Chapters;
            ////GetAllPermissionName = PermissionNames.Pages_Chapters;

            //CreatePermissionName = PermissionNames.Pages_Chapters_Create;
            //UpdatePermissionName = PermissionNames.Pages_Chapters_Update;
            //DeletePermissionName = PermissionNames.Pages_Chapters_Delete;
        }
        public async Task<ListResultDto<ChapterDto>> GetChapterBySubjectAsync(long subjectId)
        {
            var chapters = await Repository.GetAll().Where(x => x.SubjectId == subjectId).ToListAsync();

            return new ListResultDto<ChapterDto>(
                ObjectMapper.Map<List<ChapterDto>>(chapters)
            );
        }
    }
}
