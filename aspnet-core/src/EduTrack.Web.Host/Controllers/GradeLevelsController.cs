using EduTrack.Controllers;
using EduTrack.GradeLevels.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTrack.GradeLevels
{
    [Route("api/grade-levels")]
    public class GradeLevelsController : EduTrackControllerBase
    {
        private readonly IGradeLevelAppService _gradeLevelAppService;

        public GradeLevelsController(
            IGradeLevelAppService gradeLevelAppService)
        {
            _gradeLevelAppService = gradeLevelAppService;
        }

        [HttpGet]
        public async Task<List<GradeLevelDto>> GetAll()
        {
            return await _gradeLevelAppService.GetAllAsync();
        }

        [HttpPost]
        public async Task<GradeLevelDto> Create(CreateGradeLevelInput input)
        {
            return await _gradeLevelAppService.CreateAsync(input);
        }
    }
}
