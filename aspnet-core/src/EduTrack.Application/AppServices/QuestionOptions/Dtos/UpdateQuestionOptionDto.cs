using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.QuestionOptions.Dtos
{
    public class UpdateQuestionOptionDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
