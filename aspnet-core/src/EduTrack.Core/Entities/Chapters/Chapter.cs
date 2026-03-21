using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Entities.StudentProgresses;
namespace EduTrack.Entities.Chapters
{
    public class Chapter : AuditedEntity<long>
    {
        public virtual string ChapterName { get; set; }
        public virtual long SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }
        public virtual ICollection<StudentProgress> StudentProgresses { get; set; }
    }
}
