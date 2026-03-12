using Abp.Application.Services;
using EduTrack.Classes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Classes
{
    public interface IClassAppService : IAsyncCrudAppService<ClassDto, long, PagedClassResultRequestDto, CreateClassDto, ClassDto>
    {
    }
}
