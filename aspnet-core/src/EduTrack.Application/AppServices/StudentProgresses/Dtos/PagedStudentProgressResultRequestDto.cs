using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentProsesses.Dtos
{
    public class PagedStudentProgressResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
