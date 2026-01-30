using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EduTrack.Roles.Dto;
using EduTrack.Users.Dto;
using System.Threading.Tasks;

namespace EduTrack.Users;

public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
{
    Task DeActivate(EntityDto<long> user);
    Task Activate(EntityDto<long> user);
    Task<ListResultDto<RoleDto>> GetRoles();
    Task ChangeLanguage(ChangeUserLanguageDto input);

    Task<bool> ChangePassword(ChangePasswordDto input);
}
