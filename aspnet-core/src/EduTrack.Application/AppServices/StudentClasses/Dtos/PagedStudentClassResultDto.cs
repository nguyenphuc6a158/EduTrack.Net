using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses.Dtos
{
    public class PagedStudentClassResultDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
