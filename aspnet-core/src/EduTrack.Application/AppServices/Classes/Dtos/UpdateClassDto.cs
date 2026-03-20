using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Classes.Dtos
{
    public class UpdateClassDto : IEntityDto<long> 
    {
        public long Id { get; set; }
        public string ClassName { get; set; }

        public long GradeId { get; set; }

        public long TeacherId { get; set; }

    }
}
