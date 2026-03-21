using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentProsesses.Dtos
{
    public class CreateStudentProgressDto
    {
        [Required]
        public long StudentId { get; set; }
        [Required]
        public long ChapterId { get; set; }
        public float AvgScore { get; set; }
        public int TotalAttempts { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalQuestions { get; set; }
    }
}
