using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses.Dtos
{
    public class CreateStudentClassDto
    {
        [Required]
        public long StudentId { get; set; }
        [Required]
        public long ClassId { get; set; }
    }
}
