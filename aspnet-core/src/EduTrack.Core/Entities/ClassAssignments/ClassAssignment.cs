using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.Assignments;
using EduTrack.Entity.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.ClassAssignments
{
    public class ClassAssignment : AuditedEntity<long>
    {
        public virtual long AssignmentId {  get; set; }
        public virtual long ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
