using Abp.Application.Services;
using EduTrack.AppServices.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Subjects
{
    public interface ISubjectAppService: IAsyncCrudAppService<SubjectDto,long,PagedSubjectResultRequestDto,CreateSubjectDto,UpdateSubjectDto>
    {
    }
}
