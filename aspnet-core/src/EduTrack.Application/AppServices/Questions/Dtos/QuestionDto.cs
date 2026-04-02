using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class QuestionDto : EntityDto<long>
    {
        public string FileUrl { get; set; }
        public long ChapterId { get; set; }
        public string ChapterName { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
