using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments.Dtos
{
    public class ClassAssignmentDto : EntityDto<long>
    {
        public long AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime PublicTime { get; set; }
        public long CreaterUserId { get; set; }
    }
}
