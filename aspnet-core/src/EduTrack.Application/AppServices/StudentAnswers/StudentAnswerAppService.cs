using Abp.Application.Services;
using Abp.Domain.Entities;
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
    : AsyncCrudAppService<StudentAnswer, StudentAnswerDto, long, PagedStudentAnswerResultRequestDto, CreateStudentAnswerInput, UpdateStudentAnswerInput>,
      IStudentAnswerAppService
    {
        public StudentAnswerAppService(IRepository<StudentAnswer, long> repository)
            : base(repository)
        {
        }
        public async override Task<StudentAnswerDto> CreateAsync(CreateStudentAnswerInput input)
        {
            var existed = Repository.GetAll().Any(sa =>
                sa.StudentAssignmentId == input.StudentAssignmentId &&
                sa.QuestionId == input.QuestionId &&
                sa.SelectedOptionId == input.SelectedOptionId);

            if (existed)
            {
                return null;
            }

            var entity = ObjectMapper.Map<StudentAnswer>(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<StudentAnswerDto>(entity);
        }
        public async Task<StudentAnswerDto> CheckExist(CreateStudentAnswerInput input)
        {
            var entity = Repository.GetAll().FirstOrDefault(sa =>
                sa.StudentAssignmentId == input.StudentAssignmentId &&
                sa.QuestionId == input.QuestionId &&
                sa.SelectedOptionId == input.SelectedOptionId);
            if (entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<StudentAnswerDto>(entity); 
        }
    }
}
