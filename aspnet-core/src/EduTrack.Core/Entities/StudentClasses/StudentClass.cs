using Abp.Domain.Entities.Auditing;
using EduTrack.Authorization.Users;
using EduTrack.Entity.Classes;
using EduTrack.Entity.Grades;
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
        public virtual long StudentId { get; set; }
        public virtual User Student { get; set; }
        [Required]
        public virtual long ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual User AbpUse { get; set; }

    }
}
