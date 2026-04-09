using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments.Dtos
{
    public class UpdateClassAssignmentDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public long AssignmentId { get; set; }
        public long ClassId { get; set; }
        public DateTime PublicTime { get; set; }

    }
}
