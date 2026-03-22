using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entity.Classes;
using EduTrack.Entity.Grades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Entities.Questions
{
    public class Question : AuditedEntity<long>
    {
        [Required]
        public virtual string Content { get; set; }
        [Required]
        public virtual string Explanation { get; set; }
        [Required]
        public virtual long ChapterId { get; set; }
        [Required]
        public virtual int DifficultyLevel { get; set; }
        public virtual Chapter Chapters { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual ICollection<AssignmentQuestion> AssignmentQuestions { get; set; }
    }
}
