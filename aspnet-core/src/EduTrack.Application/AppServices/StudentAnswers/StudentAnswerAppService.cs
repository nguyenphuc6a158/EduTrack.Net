using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAnswers.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAnswers
{
    public class StudentAnswerAppService
    : AsyncCrudAppService<StudentAnswer, StudentAnswerDto, long, PagedStudentAnswerResultRequestDto, CreateStudentAnswerDto, UpdateStudentAnswerDto>,
      IStudentAnswerAppService
    {
        public StudentAnswerAppService(IRepository<StudentAnswer, long> repository)
            : base(repository)
        {
        }
        public async override Task<StudentAnswerDto> CreateAsync(CreateStudentAnswerDto input)
        {
            var existed = await CheckExist(input);

            if (existed)
            {
                throw new Exception("Student đã trả lời câu hỏi này rồi");
            }

            var entity = ObjectMapper.Map<StudentAnswer>(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<StudentAnswerDto>(entity);
        }
        public async Task<bool> CheckExist(CreateStudentAnswerDto input)
        {
            var exists = Repository.GetAll().Any(sa =>
                sa.StudentAssignmentId == input.StudentAssignmentId &&
                sa.QuestionId == input.QuestionId &&
                sa.SelectedOptionId == input.SelectedOptionId);
            return exists;
        }
    }
}
