using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.Classes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Classes
{
    public class ClassAppService : AsyncCrudAppService<Class, ClassDto, long, PagedClassResultRequestDto, CreateClassDto, ClassDto>, IClassAppService
    {
        public ClassAppService(IRepository<Class, long> repository) : base(repository)
        {
        }

        protected override IQueryable<Class> CreateFilteredQuery(PagedClassResultRequestDto input)
        {
            return Repository.GetAll();
        }
    }
}
