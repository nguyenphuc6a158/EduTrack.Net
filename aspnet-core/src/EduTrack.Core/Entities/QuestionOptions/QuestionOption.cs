using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudentAnswers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.QuestionOptions
{
    public class QuestionOption : AuditedEntity<long>
    {
        [Required]
        public virtual string Content { get; set; }
        [Required]
        public virtual long QuestionId { get; set; }
        [Required]
        public virtual bool IsCorrect { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
