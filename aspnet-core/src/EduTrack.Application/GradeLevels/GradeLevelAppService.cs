using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.GradeLevels.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTrack.GradeLevels
{
    public class GradeLevelAppService
        : ApplicationService, IGradeLevelAppService
    {
        private readonly IRepository<GradeLevel, int> _gradeLevelRepository;

        public GradeLevelAppService(
            IRepository<GradeLevel, int> gradeLevelRepository)
        {
            _gradeLevelRepository = gradeLevelRepository;
        }

        public async Task<GradeLevelDto> CreateAsync(CreateGradeLevelInput input)
        {
            var gradeLevel = new GradeLevel(input.Name);

            await _gradeLevelRepository.InsertAsync(gradeLevel);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<GradeLevelDto>(gradeLevel);
        }

        public async Task<List<GradeLevelDto>> GetAllAsync()
        {
            var list = await _gradeLevelRepository.GetAllListAsync();
            return ObjectMapper.Map<List<GradeLevelDto>>(list);
        }
    }
}
