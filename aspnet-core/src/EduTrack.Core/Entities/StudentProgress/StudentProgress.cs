using Abp.Domain.Entities.Auditing;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Chapters;
using EduTrack.Entity.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.StudentProgresses
{
    public class StudentProgress : AuditedEntity<long>
    {
        [Required]
        public virtual long StudentId { get; set; }
        public virtual User AbpUses { get; set; }
        [Required]
        public virtual long ChapterId { get; set; }
        public virtual Chapter Chapters { get; set; }
        public virtual float AvgScore { get; set; }
        public virtual int TotalAttempts { get; set; }
        public virtual int TotalCorrect { get; set; }
        public virtual int TotalQuestions { get; set; }

    }
}
