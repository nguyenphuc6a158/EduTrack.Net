using Abp.Application.Services;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAssignments.Dtos;
using EduTrack.Entities.StudentAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments
{
    public interface IStudentAssignmentAppService
    : IAsyncCrudAppService<
        StudentAssignmentDto,
        long,
        PagedStudentAssignmentResultRequestDto,
        CreateStudentAssignmentInput, UpdateStudentAssignmentInput>
    {
    }
}
