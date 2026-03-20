using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Grades.Dtos
{
    public class UpdateGradeDto : IEntityDto<long>
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string GradeName { get; set; }
    }
}
