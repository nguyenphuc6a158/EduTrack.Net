using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Classes
{
    public class PagedClassResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
