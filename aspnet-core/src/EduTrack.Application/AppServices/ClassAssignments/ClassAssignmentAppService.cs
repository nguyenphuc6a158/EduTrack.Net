using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Timing;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entity.Classes;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Assignment, long> _assignmentRepository;
        private readonly IRepository<Class, long> _classRepository;
        public ClassAssignmentAppService(
            IRepository<ClassAssignment, long> repository,
            IRepository<StudentClass, long> studentClassRepository,
            IRepository<User, long> userRepository,
            IRepository<Assignment, long> assignmentRepository,
            IRepository<Class, long> classRepository    
        ) : base(repository)
        {
            _studentClassRepository = studentClassRepository;
            _userRepository = userRepository;
            _assignmentRepository = assignmentRepository;
            _classRepository = classRepository;
            GetPermissionName = PermissionNames.Pages_ClassAssignments;
            GetAllPermissionName = PermissionNames.Pages_ClassAssignments;

            CreatePermissionName = PermissionNames.Pages_ClassAssignments_Create;
            UpdatePermissionName = PermissionNames.Pages_ClassAssignments_Update;
            DeletePermissionName = PermissionNames.Pages_ClassAssignments_Delete;
        }
        public async Task<List<ClassAssignmentDto>> CreateListClassAssignmentAsync(CreateListClassAssgnmentDto input)
        {
            var request = new List<ClassAssignment>();

            foreach (var classDto in input.ListClasses)
            {
                request.Add(new ClassAssignment
                {
                    AssignmentId = input.AssignmentId,
                    ClassId = classDto.Id,
                    PublicTime = input.PublicTime
                });
            }

            await Repository.InsertRangeAsync(request);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<List<ClassAssignmentDto>>(request);
        }
        public async Task<PagedResultDto<ClassAssignmentDto>> GetAllClassAssignmentByCreaterUserIdAsync(long createrUserId)
        {
            var query = Repository.GetAll().Where(x => x.CreatorUserId == createrUserId);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var classAssignments = await AsyncQueryableExecuter.ToListAsync(query);

            var classIds = classAssignments.Select(x => x.ClassId).ToList();
            var assignmentIds = classAssignments.Select(x => x.AssignmentId).ToList();

            var classes = await _classRepository.GetAll().Where(x => classIds.Contains(x.Id)).ToListAsync();
            var assignments = await _assignmentRepository.GetAll().Where(x => assignmentIds.Contains(x.Id)).ToListAsync();
            
            var result = classAssignments.Select(x =>
            {
                var classs = classes.FirstOrDefault(c => c.Id == x.ClassId);
                var assignment= assignments.FirstOrDefault(a => a.Id == x.AssignmentId);
                return new ClassAssignmentDto
                {
                    Id = x.Id,
                    ClassName = classs.ClassName,
                    ClassId = x.ClassId,
                    AssignmentId = x.AssignmentId,
                    CreaterUserId = x.CreatorUserId ?? -1,
                    AssignmentName = assignment.Title,
                    PublicTime = x.PublicTime
                };
            }).ToList();

            return new PagedResultDto<ClassAssignmentDto>(
                totalCount,
                result
            );
        }
    }
}
