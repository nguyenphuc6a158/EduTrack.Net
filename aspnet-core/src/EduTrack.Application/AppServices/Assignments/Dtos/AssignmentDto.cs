using Abp.Application.Services.Dto;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments.Dtos
{
    public class AssignmentDto : EntityDto<long>
    {
        public string Title { get; set; }
        public long ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string CreateBy { get; set; }
        public Chapter Chapters { get; set; }
    }
}
