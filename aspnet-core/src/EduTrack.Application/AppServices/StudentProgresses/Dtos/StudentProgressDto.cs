using Abp.Application.Services.Dto;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Chapters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentProsesses.Dtos
{
    public class StudentProgressDto : EntityDto<long>
    {
        public long StudentId { get; set; }
        public long ChapterId { get; set; }
        public float AvgScore { get; set; }
        public int TotalAttempts { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalQuestions { get; set; }
    }
}
