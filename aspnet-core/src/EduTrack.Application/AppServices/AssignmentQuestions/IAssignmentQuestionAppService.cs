using Abp.Application.Services;
using EduTrack.AppServices.AssignmentQuestions.Dtos;
using EduTrack.Entities.AssignmentQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions
{
    public interface IAssignmentQuestionAppService : IAsyncCrudAppService<AssignmentQuestionDto, long, PagedAssignmentQuestionResulRequestDto, CreateAssignmentQuestionDto, UpdateAssignmentQuestionDto>
    {
    }
}
