using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class UpdateQuestionDto : IEntityDto<long>
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string fileUrlAssignment { get; set; }
        public string FileUrlExplain { get; set; }
        public long ChapterId { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
