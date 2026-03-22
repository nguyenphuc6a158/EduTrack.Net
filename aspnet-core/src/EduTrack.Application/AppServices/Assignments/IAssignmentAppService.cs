using Abp.Application.Services;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.Chapters.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments
{
    public interface IAssignmentAppService : IAsyncCrudAppService<AssignmentDto, long, PagedAssignmentResultRequestDto, CreateAssignmentDto, UpdateAssignmentDto>
    {
    }
}
