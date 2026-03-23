using Abp.Domain.Entities.Auditing;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.StudentAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.StudentAssignments
{
    public class StudentAssignment : AuditedEntity<long>
    {
        public virtual long StudentId { get; set; }
        public virtual long? AssignmentId { get; set; }
        public virtual int Status { get; set; }
        public virtual float Score { get; set; }
        public virtual int TotalCorrect { get; set; }
        public virtual int TotalQuestions { get; set; }
        public virtual DateTime SubmittedAt { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual User AbpUser { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }

    }
}
