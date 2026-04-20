using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class CreateQuestionDto
    {
        public string FileUrlAssignment { get; set; }
        public string FileUrlExplain { get; set; }
        public long ChapterId { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
