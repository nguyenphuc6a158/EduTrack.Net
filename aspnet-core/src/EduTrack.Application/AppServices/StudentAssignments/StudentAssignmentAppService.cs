using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Questions;
using EduTrack.AppServices.Questions.Dtos;
using EduTrack.AppServices.StudentAssignments.Dtos;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments
{
    public class StudentAssignmentAppService
    : AsyncCrudAppService<StudentAssignment, StudentAssignmentDto, long, PagedStudentAssignmentResultRequestDto, CreateStudentAssignmentDto, UpdateStudentAssignmentDto>,
      IStudentAssignmentAppService
    {
        public StudentAssignmentAppService(IRepository<StudentAssignment, long> repository)
            : base(repository)
        {
        }
    }
}
