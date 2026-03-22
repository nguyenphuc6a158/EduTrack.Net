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
        public long ClassId { get; set; }
    }
}
