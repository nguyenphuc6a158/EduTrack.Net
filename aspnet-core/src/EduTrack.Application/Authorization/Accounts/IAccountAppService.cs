using Abp.Application.Services;
using EduTrack.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace EduTrack.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
