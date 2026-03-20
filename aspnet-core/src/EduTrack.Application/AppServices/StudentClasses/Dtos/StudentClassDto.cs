using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentClasses.Dtos
{
    public class StudentClassDto : EntityDto<long>
    {
        public long ClassId { get; set; }
        public long StudentId { get; set; }
    }
}
