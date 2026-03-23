using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments.Dtos
{
    public class StudentAssignmentDto : EntityDto<long>
    {
        public long StudentId { get; set; }
        public long AssignmentId { get; set; }
        public int Status { get; set; }
        public float Score { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
