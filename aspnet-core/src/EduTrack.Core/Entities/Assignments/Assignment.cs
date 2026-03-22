using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentProgresses;
using EduTrack.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.Assignments
{
    public class Assignment : AuditedEntity<long>
    {
        public virtual string Title { get; set; }
        public virtual long ChapterId { get; set; }
        public virtual Chapter Chapters { get; set; }
        public virtual ICollection<AssignmentQuestion> AssignmentQuestions { get; set; }
    }
}
