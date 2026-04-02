using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Castle.MicroKernel.Registration;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.Authorization;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.QuestionOptions;
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
        private readonly IRepository<QuestionOption, long> _questionOptionRepository;
        public QuestionAppService(
            IRepository<Question, long> repository,
            IRepository<Chapter, long> chapterRepository,
            IRepository<QuestionOption, long> questionOptionRepository
            ) : base(repository)
        {
            _chapterRepository = chapterRepository;
            _repository = repository;
            _questionOptionRepository = questionOptionRepository;
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
                    Id = q.Id,
                    FileUrl = q.FileUrl,
                    ChapterId = q.ChapterId,
                    ChapterName = chapter.ChapterName,
                    DifficultyLevel = q.DifficultyLevel
                };
            }).ToList();
            return new PagedResultDto<QuestionDto>(totalCount, result);
        }
        public async Task<PagedResultDto<QuestionDto>> GetQuestionByChapterAsync(long chapterId)
        {
            var query = Repository.GetAll().Where(q => q.ChapterId == chapterId);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var questions = await AsyncQueryableExecuter.ToListAsync(query);
            var chapterIds = questions.Select(x => x.ChapterId).Distinct().ToList();
            var chapters = await _chapterRepository.GetAll().Where(c => chapterIds.Contains(c.Id)).ToListAsync();
            var result = questions.Select(q =>
            {
                var chapter = chapters.FirstOrDefault(c => c.Id == q.ChapterId);

                return new QuestionDto
                {
                    Id = q.Id,
                    FileUrl = q.FileUrl,
                    ChapterId = q.ChapterId,
                    ChapterName = chapter.ChapterName,
                    DifficultyLevel = q.DifficultyLevel
                };
            }).ToList();
            return new PagedResultDto<QuestionDto>(totalCount, result);
        }
        public async Task CreateWithOptionsAsync(CreateQuestionWithOptionsDto input)
        {
            if (input.Answers == null || !input.Answers.Any())
            {
                throw new UserFriendlyException("Câu hỏi phải có đáp án");
            }

            if (!input.Answers.Any(x => x.IsCorrect))
            {
                throw new UserFriendlyException("Phải có ít nhất 1 đáp án đúng");
            }

            var question = ObjectMapper.Map<Question>(input);

            await Repository.InsertAsync(question);
            await CurrentUnitOfWork.SaveChangesAsync();

            foreach (var answer in input.Answers)
            {
                var option = new QuestionOption
                {
                    QuestionId = question.Id,
                    Content = answer.Content,
                    IsCorrect = answer.IsCorrect
                };

                await _questionOptionRepository.InsertAsync(option);
            }
        }
        public async Task UpdateWithOptionsAsync(UpdateQuestionWithOptionsDto input)
        {
            // 1. Lấy question
            var question = await Repository.GetAsync(input.Id);

            if (question == null)
            {
                throw new UserFriendlyException("Không tìm thấy câu hỏi");
            }

            // Validate input answers before performing any changes
            if (input.Answers == null || !input.Answers.Any())
            {
                throw new UserFriendlyException("Câu hỏi phải có đáp án");
            }

            if (!input.Answers.Any(x => x.IsCorrect))
            {
                throw new UserFriendlyException("Phải có ít nhất 1 đáp án đúng");
            }

            // 2. Update question
            question.FileUrl = input.FileUrl;
            question.ChapterId = input.ChapterId;
            question.DifficultyLevel = input.DifficultyLevel;

            await Repository.UpdateAsync(question);

            // 3. Lấy danh sách option hiện tại
            var existingOptions = await _questionOptionRepository
                .GetAll()
                .Where(x => x.QuestionId == input.Id)
                .ToListAsync();

            // 4. Xoá option cũ không còn trong input
            var inputIds = input.Answers
                .Where(x => x.Id.HasValue)
                .Select(x => x.Id.Value)
                .ToList();

            var toDelete = existingOptions
                .Where(x => !inputIds.Contains(x.Id))
                .ToList();

            foreach (var item in toDelete)
            {
                await _questionOptionRepository.DeleteAsync(item);
            }

            // 5. Update hoặc thêm mới
            foreach (var answer in input.Answers)
            {
                if (answer.Id.HasValue)
                {
                    // update if exists, otherwise create new
                    var existing = existingOptions.FirstOrDefault(x => x.Id == answer.Id.Value);
                    if (existing != null)
                    {
                        existing.Content = answer.Content;
                        existing.IsCorrect = answer.IsCorrect;

                        await _questionOptionRepository.UpdateAsync(existing);
                    }
                    else
                    {
                        var newOption = new QuestionOption
                        {
                            QuestionId = question.Id,
                            Content = answer.Content,
                            IsCorrect = answer.IsCorrect
                        };

                        await _questionOptionRepository.InsertAsync(newOption);
                    }
                }
                else
                {
                    // thêm mới
                    var newOption = new QuestionOption
                    {
                        QuestionId = question.Id,
                        Content = answer.Content,
                        IsCorrect = answer.IsCorrect
                    };

                    await _questionOptionRepository.InsertAsync(newOption);
                }
            }
            // Persist changes
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
