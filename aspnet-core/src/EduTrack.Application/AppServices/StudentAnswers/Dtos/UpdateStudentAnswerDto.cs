using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAnswers.Dtos
{
    public class UpdateStudentAnswerDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public long StudentAssignmentIdƠ { get; set; }
        public long QuestionId { get; set; }
        public long SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
