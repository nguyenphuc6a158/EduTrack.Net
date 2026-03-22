using Abp.Application.Services;
using EduTrack.AppServices.Assignments.Dtos;
using EduTrack.AppServices.Chapters.Dtos;
using EduTrack.AppServices.ClassAssignments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments
{
    public interface IClassAssignmentAppService : IAsyncCrudAppService<ClassAssignmentDto, long, PagedClassAssignmentResultRequestDto, CreateClassAssignmentDto, UpdateClassAssignmentDto>
    {
    }
}
