using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions.Dtos
{
    public class CreateQuestionOptionDto
    {
        public string Content { get; set; }
        public long QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
