using Abp.Domain.Entities.Auditing;
using EduTrack.Entity.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entity.Grades
{
    public class Grade : AuditedEntity<long>
    {
        [Required]
        public virtual string GradeName { get; set; }

        public virtual ICollection<Class> Classses { get; set; }
    }
}
