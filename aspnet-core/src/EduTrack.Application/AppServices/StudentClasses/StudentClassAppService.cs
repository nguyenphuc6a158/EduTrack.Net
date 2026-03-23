using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.Authorization;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses
{
    [AbpAuthorize]
    public class StudentClassAppService : AsyncCrudAppService<StudentClass, StudentClassDto, long, PagedStudentClassResultRequestDto, CreateStudentClassDto, UpdateStudentClassDto>,IStudentClassAppService
    {
        public StudentClassAppService(IRepository<StudentClass, long> repository)
        : base(repository)
        {
            GetPermissionName = PermissionNames.Pages_StudentClasses;
            GetAllPermissionName = PermissionNames.Pages_StudentClasses;

            CreatePermissionName = PermissionNames.Pages_StudentClasses_Create;
            UpdatePermissionName = PermissionNames.Pages_StudentClasses_Update;
            DeletePermissionName = PermissionNames.Pages_StudentClasses_Delete;
        }
    }
}
