using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses
{
    public class StudentClassAppService : AsyncCrudAppService<StudentClass, StudentClassDto, long, PagedStudentClassResultRequestDto, CreateStudentClassDto, UpdateStudentClassDto>,IStudentClassAppService
    {
        public StudentClassAppService(IRepository<StudentClass, long> repository)
        : base(repository)
        {
        }
    }
}
