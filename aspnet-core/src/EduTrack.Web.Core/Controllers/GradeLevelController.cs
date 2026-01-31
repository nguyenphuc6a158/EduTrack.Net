using EduTrack.GradeLevels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Controllers
{
    [Route("api/services/app/GradeLevels")]
    [ApiController]
    public class GradeLevelController : ControllerBase
    {
        private readonly GradeLevelAppService _service;

        public GradeLevelController(GradeLevelAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<GradeLevelDto>> GetAll()
        {
            return await _service.GetListAsync();
        }
    }
}
