using Abp.Application.Services;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.Entities.StudenClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses
{
    public interface IStudentClassAppService : IAsyncCrudAppService<StudentClassDto, long, PagedStudentClassResultRequestDto, CreateStudentClassDto, UpdateStudentClassDto>
    {

    }
}
