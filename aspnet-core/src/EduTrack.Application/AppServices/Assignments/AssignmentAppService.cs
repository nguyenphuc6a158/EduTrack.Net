using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.Chapters;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments
{
    public class AssignmentAppService
    : AsyncCrudAppService<Assignment, AssignmentDto, long, PagedAssignmentResultRequestDto, CreateAssignmentDto, UpdateAssignmentDto>,
      IAssignmentAppService
    {
        public AssignmentAppService(IRepository<Assignment, long> repository)
            : base(repository)
        {
        }
    }
}
