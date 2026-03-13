using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Classes.Dtos
{
    public class ClassDto : EntityDto<long>
    {
        public string ClassName { get; set; }

        public int Level { get; set; }
        public long TeacherID { get; set; }
    }
}
