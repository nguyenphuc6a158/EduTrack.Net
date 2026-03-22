using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.AssignmentQuestions
{
    public class AssignmentQuestion : AuditedEntity<long>
    {
        public virtual long AssignmentId { get; set; }
        public virtual long QuestionId { get; set; }
        public virtual int OrderIndex { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual Question Question { get; set; }

    }
}
