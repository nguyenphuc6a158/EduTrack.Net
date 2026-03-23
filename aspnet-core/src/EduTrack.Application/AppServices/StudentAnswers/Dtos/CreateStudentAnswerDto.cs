using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAnswers.Dtos
{
    public class CreateStudentAnswerDto
    {
        public long StudentAssignmentIdƠ { get; set; }
        public long QuestionId { get; set; }
        public long SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
