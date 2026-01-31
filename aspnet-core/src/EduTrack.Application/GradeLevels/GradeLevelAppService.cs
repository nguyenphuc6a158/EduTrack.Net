using EduTrack.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.GradeLevels
{
    public class GradeLevelAppService : EduTrackAppServiceBase
    {
        private readonly IGradeLevelRepository _repository;

        public GradeLevelAppService(IGradeLevelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GradeLevelDto>> GetListAsync()
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(x => new GradeLevelDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
