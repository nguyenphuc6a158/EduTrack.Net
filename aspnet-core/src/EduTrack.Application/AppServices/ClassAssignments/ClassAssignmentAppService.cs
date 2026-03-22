using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.Chapters;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.ClassAssignments.Dtos;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.ClassAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments
{
    public class ClassAssignmentAppService
    : AsyncCrudAppService<ClassAssignment, ClassAssignmentDto, long, PagedClassAssignmentResultRequestDto, CreateClassAssignmentDto, UpdateClassAssignmentDto>,
      IClassAssignmentAppService
    {
        public ClassAssignmentAppService(IRepository<ClassAssignment, long> repository)
            : base(repository)
        {
        }
    }
}
