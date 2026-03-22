using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments.Dtos
{
    public class PagedClassAssignmentResultRequestDto : PagedResultRequestDto
    {
        public string KeyWord { get; set; }
    }
}
