using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Subjects.Dto
{
    public class UpdateSubjectDto : IEntityDto<long>
    {
        public long Id { get; set; }
        public string SubjectName { get; set; }
    }
}
