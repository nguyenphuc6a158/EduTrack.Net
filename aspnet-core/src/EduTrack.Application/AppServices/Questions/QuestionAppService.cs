using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Castle.MicroKernel.Registration;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.Questions;
using EduTrack.Entity.Classes;
using EduTrack.Entity.Grades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions
{
    [AbpAuthorize]
    public class QuestionAppService
    : AsyncCrudAppService<Question, QuestionDto, long, PagedQuestionResultRequestDto, CreateQuestionDto, UpdateQuestionDto>,
      IQuestionAppService
    {
        private readonly IRepository<Chapter, long> _chapterRepository;
        private readonly IRepository<Question, long> _repository;
        public QuestionAppService(
            IRepository<Question, long> repository,
            IRepository<Chapter, long> chapterRepository
            ) : base(repository)
        {
            _chapterRepository = chapterRepository;
            _repository = repository;
            GetPermissionName = PermissionNames.Pages_Questions;
            GetAllPermissionName = PermissionNames.Pages_Questions;

            CreatePermissionName = PermissionNames.Pages_Questions_Create;
            UpdatePermissionName = PermissionNames.Pages_Questions_Update;
            DeletePermissionName = PermissionNames.Pages_Questions_Delete;
        }

        public override async Task<PagedResultDto<QuestionDto>> GetAllAsync(PagedQuestionResultRequestDto input)
        {
            var query = Repository.GetAll();
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var questions = await AsyncQueryableExecuter.ToListAsync(
                ApplyPaging(query, input)
            );
            var chapterIds = questions.Select(x => x.ChapterId).Distinct().ToList();
            var chapters = await _chapterRepository.GetAll().Where(c => chapterIds.Contains(c.Id)).ToListAsync();
            var result = questions.Select(q =>
            {
                var chapter = chapters.FirstOrDefault(c => c.Id == q.ChapterId);

                return new QuestionDto
                {
                    Content = q.Content,
                    Explanation = q.Explanation,
                    ChapterId = q.ChapterId,
                    ChapterName = chapter.ChapterName,
                    DifficultyLevel = q.DifficultyLevel
                };
            }).ToList();
            return new PagedResultDto<QuestionDto>(totalCount, result);
        }
    }
}
