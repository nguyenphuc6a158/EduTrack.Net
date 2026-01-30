using Abp.Application.Services;
using EduTrack.MultiTenancy.Dto;

namespace EduTrack.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

