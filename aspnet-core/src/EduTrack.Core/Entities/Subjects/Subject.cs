using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.Subjects
{
    public class Subject : AuditedEntity<long>
    {
        public virtual string SubjectName { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
