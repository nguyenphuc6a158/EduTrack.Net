using Abp.Application.Services;
using EduTrack.GradeLevels.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTrack.GradeLevels
{
    public interface IGradeLevelAppService : IApplicationService
    {
        Task<GradeLevelDto> CreateAsync(CreateGradeLevelInput input);
        Task<List<GradeLevelDto>> GetAllAsync();
    }
}
