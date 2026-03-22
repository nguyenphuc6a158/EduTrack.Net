using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.AssignmentQuestions.Dtos;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions
{
    public class AssignmentQuestionAppService : AsyncCrudAppService<AssignmentQuestion, AssignmentQuestionDto, long, PagedAssignmentQuestionResulRequestDto, CreateAssignmentQuestionDto, UpdateAssignmentQuestionDto>, IAssignmentQuestionAppService
    {
        public AssignmentQuestionAppService(IRepository<AssignmentQuestion, long> repository)
            : base(repository)
        {
        }
    }
}
