using Abp.Application.Services.Dto;
using EduTrack.AppServices.QuestionOptions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Questions.Dtos
{
    public class UpdateQuestionWithOptionsDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public string FileUrlAssignment { get; set; }
        public string FileUrlExplain { get; set; }
        public long ChapterId { get; set; }
        public int DifficultyLevel { get; set; }

        public List<CreateQuestionOptionDto> Answers { get; set; }
    }
}
