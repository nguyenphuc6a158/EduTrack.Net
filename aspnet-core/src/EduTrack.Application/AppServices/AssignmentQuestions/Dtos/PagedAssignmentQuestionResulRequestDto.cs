using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions.Dtos
{
    public class PagedAssignmentQuestionResulRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
