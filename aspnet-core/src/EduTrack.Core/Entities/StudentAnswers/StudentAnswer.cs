using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.StudentAnswers
{
    public class StudentAnswer : AuditedEntity<long>
    {
        public virtual long StudentAssignmentId { get; set; }
        public virtual StudentAssignment StudentAssignment { get; set; }
        public virtual long? QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual long? SelectedOptionId { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
        public virtual bool IsCorrect { get; set; }
    }
}
