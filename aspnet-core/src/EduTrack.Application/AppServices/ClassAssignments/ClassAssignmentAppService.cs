using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Domain.Repositories;
using Abp.Timing;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.StudenClasses;
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
        private readonly IRepository<StudentClass, long> _studentClassRepository;
        public ClassAssignmentAppService(
            IRepository<ClassAssignment, long> repository,
            IRepository<StudentClass, long> studentClassRepository
        ) : base(repository)
        {
            _studentClassRepository = studentClassRepository;
            GetPermissionName = PermissionNames.Pages_ClassAssignments;
            GetAllPermissionName = PermissionNames.Pages_ClassAssignments;

            CreatePermissionName = PermissionNames.Pages_ClassAssignments_Create;
            UpdatePermissionName = PermissionNames.Pages_ClassAssignments_Update;
            DeletePermissionName = PermissionNames.Pages_ClassAssignments_Delete;
        }
    }
}
