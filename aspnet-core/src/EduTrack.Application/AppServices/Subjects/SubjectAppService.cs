using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Subjects.Dto;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Subjects
{
    public class SubjectAppService : AsyncCrudAppService<Subject,SubjectDto,long,PagedSubjectResultRequestDto,CreateSubjectDto,UpdateSubjectDto>, ISubjectAppService
    {
        public SubjectAppService(IRepository<Subject, long> repository)
        : base(repository)
        {
        }
    }
}
