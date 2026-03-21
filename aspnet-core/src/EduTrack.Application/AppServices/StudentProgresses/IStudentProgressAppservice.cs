using Abp.Application.Services;
using EduTrack.AppServices.StudentClasses.Dtos;
using EduTrack.AppServices.StudentProsesses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentProsesses
{
    public interface IStudentProgressAppservice : IAsyncCrudAppService<StudentProgressDto, long, PagedStudentProgressResultRequestDto, CreateStudentProgressDto, UpdateStudentProgressDto>
    {

    }
}
