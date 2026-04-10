using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entity.Classes;
using EduTrack.Entity.Grades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Classes
{
    [AbpAuthorize]
    public class ClassAppService : AsyncCrudAppService<Class, ClassDto, long, PagedClassResultRequestDto, CreateClassDto, UpdateClassDto>, IClassAppService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<Grade, long> _gradeRepository;
        public ClassAppService(
            IRepository<Class, long> repository,
            UserManager userManager,
            IRepository<Grade, long> gradeRepository
        ) : base(repository)
        {
            _userManager = userManager;
            _gradeRepository = gradeRepository;
            GetPermissionName = PermissionNames.Pages_Classes;
            GetAllPermissionName = PermissionNames.Pages_Classes;

            CreatePermissionName = PermissionNames.Pages_Classes_Create;
            UpdatePermissionName = PermissionNames.Pages_Classes_Update;
            DeletePermissionName = PermissionNames.Pages_Classes_Delete;
        }
        public override async Task<ClassDto> CreateAsync(CreateClassDto input)
        {
            bool exist = await Repository.GetAll().AnyAsync(c => c.GradeId == input.GradeId && c.ClassName == input.ClassName);
            if (exist)
            {
                throw new UserFriendlyException("Khối này đã có lớp tên " + input.ClassName);
            }

            var user = await _userManager.GetUserByIdAsync(input.TeacherId);

            if (user == null)
            {
                throw new UserFriendlyException("User không tồn tại");
            }

            if (!await _userManager.IsInRoleAsync(user, "Teacher") && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new UserFriendlyException("User không phải là Teacher");
            }

            return await base.CreateAsync(input);
        }
        public override async Task<ClassDto> UpdateAsync(UpdateClassDto input)
        {
            var user = await _userManager.GetUserByIdAsync(input.TeacherId);

            if (user == null)
            {
                throw new UserFriendlyException("User không tồn tại");
            }

            if (!await _userManager.IsInRoleAsync(user, "Teacher") && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new UserFriendlyException("User không phải là Teacher");
            }

            return await base.UpdateAsync(input);
        }
        public async Task<PagedResultDto<ClassDto>> GetClassByGradeAsync(long gradeId)
        {
            // Lấy tất cả class có gradeId
            var query = Repository.GetAll().Where(c => c.GradeId == gradeId);

            // Tổng số
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            // Lấy danh sách
            var classes = await AsyncQueryableExecuter.ToListAsync(query);

            var teacherIds = classes.Select(x => x.TeacherId).Distinct().ToList();
            var gradeIds = classes.Select(x => x.GradeId).Distinct().ToList();

            var users = await _userManager.Users.Where(u => teacherIds.Contains(u.Id)).ToListAsync();
            var grades = await _gradeRepository.GetAll().Where(g => gradeIds.Contains(g.Id)).ToListAsync();

            var result = classes.Select(c =>
            {
                var user = users.FirstOrDefault(u => u.Id == c.TeacherId);
                var grade = grades.FirstOrDefault(g => g.Id == c.GradeId);

                return new ClassDto
                {
                    Id = c.Id,
                    ClassName = c.ClassName,
                    TeacherId = c.TeacherId,
                    GradeId = c.GradeId,
                    TeacherName = user?.FullName,
                    GradeName = grade?.GradeName
                };
            }).ToList();

            return new PagedResultDto<ClassDto>(totalCount, result);
        }
        public async Task<PagedResultDto<ClassDto>> GetClassByTeacherAsync(long teacherId)
        {
            // Lấy tất cả class có gradeId
            var query = Repository.GetAll().Where(c => c.TeacherId == teacherId);

            // Tổng số
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            // Lấy danh sách
            var classes = await AsyncQueryableExecuter.ToListAsync(query);

            var gradeIds = classes.Select(x => x.GradeId).Distinct().ToList();

            var grades = await _gradeRepository.GetAll().Where(g => gradeIds.Contains(g.Id)).ToListAsync();

            var teacher = await _userManager.GetUserByIdAsync(teacherId);

            var result = classes.Select( c =>
            {
                var grade = grades.FirstOrDefault(g => g.Id == c.GradeId);

                return new ClassDto
                {
                    Id = c.Id,
                    ClassName = c.ClassName,
                    TeacherId = c.TeacherId,
                    GradeId = c.GradeId,
                    TeacherName = teacher?.FullName,
                    GradeName = grade?.GradeName
                };
            }).ToList();

            return new PagedResultDto<ClassDto>(totalCount, result);
        }
        public override async Task<PagedResultDto<ClassDto>> GetAllAsync(PagedClassResultRequestDto input)
        {
            var query = Repository.GetAll();
            
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            
            var classes = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );

            var teacherIds = classes.Select(x => x.TeacherId).Distinct().ToList();
            var gradeIds = classes.Select(x => x.GradeId).Distinct().ToList();

            var users = await _userManager.Users.Where(u => teacherIds.Contains(u.Id)).ToListAsync();// Lấy danh sách user (teacher)
            var grades = await _gradeRepository.GetAll().Where(g => gradeIds.Contains(g.Id)).ToListAsync();// Lấy danh sách grade

            var result = classes.Select(c =>
            {
                var user = users.FirstOrDefault(u => u.Id == c.TeacherId);
                var grade = grades.FirstOrDefault(g => g.Id == c.GradeId);

                return new ClassDto
                {
                    Id = c.Id,
                    ClassName = c.ClassName,
                    TeacherId = c.TeacherId,
                    GradeId = c.GradeId,
                    TeacherName = user?.FullName,
                    GradeName = grade?.GradeName
                };
            }).ToList();
            return new PagedResultDto<ClassDto>(totalCount, result);
        }
            //protected override IQueryable<Class> CreateFilteredQuery(PagedClassResultRequestDto input)
            //{
            //    return Repository.GetAll();
            //}
        }
}
