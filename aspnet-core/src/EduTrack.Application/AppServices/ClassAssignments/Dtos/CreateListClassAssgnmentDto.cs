using EduTrack.AppServices.Classes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.ClassAssignments.Dtos
{
    public class CreateListClassAssgnmentDto
    {
        public long AssignmentId { get; set; }
        public List<ClassDto> ListClasses { get; set; }
        public DateTime PublicTime { get; set; }
    }
}
