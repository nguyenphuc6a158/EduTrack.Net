using Abp.Domain.Entities.Auditing;
using EduTrack.Authorization.Users;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.Subjects;
using EduTrack.Entity.Grades;
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
        public virtual Grade Grade { get; set; }
        public virtual User AbpUse { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<ClassAssignment> ClassAssignments { get; set; }
    }
}
