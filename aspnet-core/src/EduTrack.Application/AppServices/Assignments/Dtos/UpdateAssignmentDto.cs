using Abp.Application.Services.Dto;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments.Dtos
{
    public class UpdateAssignmentDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ChapterId { get; set; }
        public Chapter Chapters { get; set; }
    }
}
