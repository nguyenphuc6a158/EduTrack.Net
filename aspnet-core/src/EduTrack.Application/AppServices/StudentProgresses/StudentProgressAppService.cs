using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.StudentClasses;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.AppServices.StudentProsesses;
using EduTrack.AppServices.StudentProsesses.Dtos;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.StudentProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentProgresses
{
    public class StudentProgressAppService : AsyncCrudAppService<StudentProgress, StudentProgressDto, long, PagedStudentProgressResultRequestDto, CreateStudentProgressDto, UpdateStudentProgressDto>, IStudentProgressAppservice
    {
        public StudentProgressAppService(IRepository<StudentProgress, long> repository)
        : base(repository)
        {
        }
    }
}
