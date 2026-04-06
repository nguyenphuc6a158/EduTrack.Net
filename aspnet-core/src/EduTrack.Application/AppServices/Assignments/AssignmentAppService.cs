using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments
{
    [AbpAuthorize]
    public class AssignmentAppService
    : AsyncCrudAppService<Assignment, AssignmentDto, long, PagedAssignmentResultRequestDto, CreateAssignmentDto, UpdateAssignmentDto>,
      IAssignmentAppService
    {
        private readonly IRepository<AssignmentQuestion, long> _assignmentQuestionRepository;
        private readonly IRepository<Chapter, long> _chapterRepository;
        private readonly IRepository<User, long> _userRepository;

        public AssignmentAppService(
            IRepository<Assignment, long> repository,
            IRepository<AssignmentQuestion, long> assignmentQuestionRepository,
            IRepository<User, long> userRepository,
            IRepository<Chapter, long> chapterRepository
        ) : base(repository)
        {
            _assignmentQuestionRepository = assignmentQuestionRepository;
            _userRepository = userRepository;
            _chapterRepository = chapterRepository;
            GetPermissionName = PermissionNames.Pages_Assignments;
            GetAllPermissionName = PermissionNames.Pages_Assignments;

            CreatePermissionName = PermissionNames.Pages_Assignments_Create;
            UpdatePermissionName = PermissionNames.Pages_Assignments_Update;
            DeletePermissionName = PermissionNames.Pages_Assignments_Delete;
        }
        public async Task CreateWithQuestionsAsync(CreateWithQuestionsDto input)
        {
            var assignment = ObjectMapper.Map<Assignment>(input);

            await Repository.InsertAsync(assignment);
            await CurrentUnitOfWork.SaveChangesAsync();

            var assignmentQuestions = input.assignmentQuestions.Select(q => new AssignmentQuestion
            {
                QuestionId = q.QuestionId,
                AssignmentId = assignment.Id,
                OrderIndex = q.OrderIndex,
            }).ToList();

            foreach (var item in assignmentQuestions)
            {
                _assignmentQuestionRepository.InsertAsync(item);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }
        public override async Task<PagedResultDto<AssignmentDto>> GetAllAsync(PagedAssignmentResultRequestDto input)
        {
            var query = Repository.GetAll();

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            var assignments = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );

            var ChapterIds = assignments.Select(x => x.ChapterId).Distinct().ToList();
            var chapters = await _chapterRepository.GetAll().Where(c => ChapterIds.Contains(c.Id)).ToListAsync();
            var userIds = assignments.Select(x => x.CreatorUserId).Distinct().ToList();
            var users = await _userRepository.GetAll().Where(u => userIds.Contains(u.Id)).ToListAsync();
            var result = assignments.Select(a =>
            {
                var chapter = chapters.FirstOrDefault(c => c.Id == a.ChapterId);
                var user = users.FirstOrDefault(u => u.Id == a.CreatorUserId);
                return new AssignmentDto
                {
                    Id = a.Id,
                    ChapterId = a.ChapterId,
                    Title = a.Title,
                    ChapterName = chapter.ChapterName,
                    CreateBy = user.FullName
                };
            }).ToList();
            return new PagedResultDto<AssignmentDto>(totalCount, result);
        }
    }
}
