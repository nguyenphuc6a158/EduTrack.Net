using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entity.Classes
{
    public class Class : AuditedEntity<long>
    {
        [Required]
        public virtual string ClassName { get; set; }
        [Required]
        public virtual long GradeId { get; set; }
        [Required]
        public virtual long TeacherId { get; set; }
    }
}
