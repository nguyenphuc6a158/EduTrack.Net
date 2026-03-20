using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.StudenClasses
{
    public class StudentClass : AuditedEntity<long>
    {
        [Required]
        public virtual string StudentId { get; set; }
        [Required]
        public virtual long ClassId { get; set; }

    }
}
