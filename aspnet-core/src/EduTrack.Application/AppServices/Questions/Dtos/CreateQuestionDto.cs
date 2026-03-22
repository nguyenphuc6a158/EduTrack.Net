using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class CreateQuestionDto
    {
        public string Content { get; set; }
        public string Explanation { get; set; }
        public long ChapterId { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
