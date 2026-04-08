using EduTrack.AppServices.AssignmentQuestions.Dtos;
using EduTrack.AppServices.QuestionOptions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Assignments.Dtos
{
    public class UpdateAssignmentWithQuestionsDto
    {
        public long Id { get; set; }
        public string title { get; set; }
        public long chapterId { get; set; }
        public List<CreateAssignmentQuestionDto> assignmentQuestions { get; set; }

    }
}
