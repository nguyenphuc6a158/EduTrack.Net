using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments.Dtos
{
    public class CreateAssignmentDto
    {
        public string Title { get; set; }
        public long ChapterId { get; set; }
        public Chapter Chapters { get; set; }
    }
}
