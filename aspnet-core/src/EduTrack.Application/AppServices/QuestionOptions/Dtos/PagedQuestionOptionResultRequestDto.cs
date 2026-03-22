using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions.Dtos
{
    public class PagedQuestionOptionResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
