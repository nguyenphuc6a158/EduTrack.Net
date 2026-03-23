using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.Chapters;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.ClassAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments
{
    [AbpAuthorize]
    public class ClassAssignmentAppService
    : AsyncCrudAppService<ClassAssignment, ClassAssignmentDto, long, PagedClassAssignmentResultRequestDto, CreateClassAssignmentDto, UpdateClassAssignmentDto>,
      IClassAssignmentAppService
    {
        public ClassAssignmentAppService(IRepository<ClassAssignment, long> repository)
            : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_ClassAssignments;
            GetAllPermissionName = PermissionNames.Pages_ClassAssignments;

            CreatePermissionName = PermissionNames.Pages_ClassAssignments_Create;
            UpdatePermissionName = PermissionNames.Pages_ClassAssignments_Update;
            DeletePermissionName = PermissionNames.Pages_ClassAssignments_Delete;
        }
    }
}
