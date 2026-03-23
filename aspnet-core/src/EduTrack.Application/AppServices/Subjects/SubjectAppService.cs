using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Subjects.Dto;
using EduTrack.Authorization;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Subjects
{
    [AbpAuthorize(PermissionNames.Pages_Subjects)]
    public class SubjectAppService : AsyncCrudAppService<Subject,SubjectDto,long,PagedSubjectResultRequestDto,CreateSubjectDto,UpdateSubjectDto>, ISubjectAppService
    {
        public SubjectAppService(IRepository<Subject, long> repository)
        : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_Subjects;
            GetAllPermissionName = PermissionNames.Pages_Subjects;

            CreatePermissionName = PermissionNames.Pages_Subjects_Create;
            UpdatePermissionName = PermissionNames.Pages_Subjects_Update;
            DeletePermissionName = PermissionNames.Pages_Subjects_Delete;
        }
    }
}
