using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using EduTrack.AppServices.Classes.Dtos;
using EduTrack.Entity.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduTrack.Authorization.Users;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Classes
{
    public class ClassAppService : AsyncCrudAppService<Class, ClassDto, long, PagedClassResultRequestDto, CreateClassDto, UpdateClassDto>, IClassAppService
    {
        private readonly UserManager _userManager;
        public ClassAppService(
            IRepository<Class, long> repository,
            UserManager userManager
        ) : base(repository)
        {
            _userManager = userManager;
        }
        public override async Task<ClassDto> CreateAsync(CreateClassDto input)
        {
            var user = await _userManager.GetUserByIdAsync(input.TeacherId);

            if (user == null)
            {
                throw new UserFriendlyException("User không tồn tại");
            }

            if (!await _userManager.IsInRoleAsync(user, "Teacher") && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new UserFriendlyException("User không phải là Teacher");
            }

            return await base.CreateAsync(input);
        }
        public override async Task<ClassDto> UpdateAsync(UpdateClassDto input)
        {
            var user = await _userManager.GetUserByIdAsync(input.TeacherId);

            if (user == null)
            {
                throw new UserFriendlyException("User không tồn tại");
            }

            if (!await _userManager.IsInRoleAsync(user, "Teacher"))
            {
                throw new UserFriendlyException("User không phải là Teacher");
            }

            return await base.UpdateAsync(input);
        }
        protected override IQueryable<Class> CreateFilteredQuery(PagedClassResultRequestDto input)
        {
            return Repository.GetAll();
        }
    }
}
