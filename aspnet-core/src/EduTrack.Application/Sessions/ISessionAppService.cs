using Abp.Application.Services;
using EduTrack.Sessions.Dto;
using System.Threading.Tasks;

namespace EduTrack.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
