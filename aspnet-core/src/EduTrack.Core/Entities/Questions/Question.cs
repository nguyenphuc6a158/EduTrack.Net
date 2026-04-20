using Abp.Domain.Entities.Auditing;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.StudentAnswers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduTrack.Entities.Questions
{
    public class Question : FullAuditedEntity<long>
    {
        [Required]
        public virtual string FileUrlAssignment { get; set; }
        public virtual string FileUrlExplain { get; set; }
        [Required]
        public virtual long ChapterId { get; set; }
        [Required]
        public virtual int DifficultyLevel { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
        public virtual ICollection<AssignmentQuestion> AssignmentQuestions { get; set; }
    }
}
