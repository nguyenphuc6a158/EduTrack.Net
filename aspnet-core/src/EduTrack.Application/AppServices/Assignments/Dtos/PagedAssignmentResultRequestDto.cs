using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments.Dtos
{
    public class PagedAssignmentResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
