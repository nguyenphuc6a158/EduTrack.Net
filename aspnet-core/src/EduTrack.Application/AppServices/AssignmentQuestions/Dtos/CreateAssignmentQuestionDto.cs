using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.AssignmentQuestions.Dtos
{
    public class CreateAssignmentQuestionDto
    {
        public long AssignmentId { get; set; }
        public long QuestionId { get; set; }
        public int OrderIndex { get; set; }
    }
}
