using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Castle.MicroKernel.Registration;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entity.Classes;
using EduTrack.Entity.Grades;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager _userManager;
        private readonly IRepository<Class, long> _classRepository;
        public StudentClassAppService(
            IRepository<StudentClass, long> repository,
            UserManager userManager,
            IRepository<Class, long> classRepository
        ) : base(repository)
        {
            _userManager = userManager;
            _classRepository = classRepository;
            GetPermissionName = PermissionNames.Pages_StudentClasses;
            GetAllPermissionName = PermissionNames.Pages_StudentClasses;
            CreatePermissionName = PermissionNames.Pages_StudentClasses_Create;
            UpdatePermissionName = PermissionNames.Pages_StudentClasses_Update;
            DeletePermissionName = PermissionNames.Pages_StudentClasses_Delete;
        }
        public override async Task<PagedResultDto<StudentClassDto>> GetAllAsync(PagedStudentClassResultRequestDto input)
        {
            var query = Repository.GetAll();
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var studentClasses = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );
            var studentIds = studentClasses.Select(x => x.StudentId).Distinct().ToList();
            var classIds = studentClasses.Select(x => x.ClassId).Distinct().ToList();
            var users = await _userManager.Users.Where(u => studentIds.Contains(u.Id)).ToListAsync();
            var classes = await _classRepository.GetAll().Where(c => classIds.Contains(c.Id)).ToListAsync();
            var result = studentClasses.Select(sc =>
            {
                var user = users.FirstOrDefault(u => u.Id == sc.StudentId);
                var classEntity = classes.FirstOrDefault(c => c.Id == sc.ClassId);
                return new StudentClassDto
                {
                    Id = sc.Id,
                    StudentId = sc.StudentId,
                    StudentName = user?.FullName,
                    ClassId = sc.ClassId,
                    ClassName = classEntity?.ClassName
                };
            }).ToList();
            return new PagedResultDto<StudentClassDto>(totalCount, result);
        }
        public async Task<PagedResultDto<StudentClassDto>> GetStudentByClassAsync(PagedStudentClassResultRequestDto input, long classId)
        {
            var query = Repository.GetAll().Where(x => x.ClassId == classId);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var studentClasses = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );
            var studentIds = studentClasses.Select(x => x.StudentId).Distinct().ToList();
            var users = await _userManager.Users.Where(u => studentIds.Contains(u.Id)).ToListAsync();
            var classEntity = await _classRepository.GetAsync(classId);
            var result = studentClasses.Select(sc =>
            {
                var userDict = users.ToDictionary(u => u.Id);
                var user = userDict.GetValueOrDefault(sc.StudentId);
                return new StudentClassDto
                {
                    Id = sc.Id,
                    StudentId = sc.StudentId,
                    StudentName = user?.FullName,
                    ClassId = sc.ClassId,
                    ClassName = classEntity?.ClassName
                };
            }).ToList();
            return new PagedResultDto<StudentClassDto>(totalCount, result);
        }
    }
}
