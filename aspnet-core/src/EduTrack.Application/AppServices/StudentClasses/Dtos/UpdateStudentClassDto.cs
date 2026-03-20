using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses.Dtos
{
    public class UpdateStudentClassDto : IEntityDto<long>
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long StudentId { get; set; }
        [Required]
        public long ClassId { get; set; }
    }
}
