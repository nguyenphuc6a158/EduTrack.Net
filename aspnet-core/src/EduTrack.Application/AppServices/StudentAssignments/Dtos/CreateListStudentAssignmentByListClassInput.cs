using EduTrack.AppServices.Classes.Dtos;
using EduTrack.Entity.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments.Dtos
{
    public class CreateListStudentAssignmentByListClassInput
    {
        public List<ClassDto> ListClasses { get; set; }
        public long AssignmentId { get; set; }
        public virtual int TotalQuestions { get; set; }
        public virtual DateTime SubmittedAt { get; set; }
    }
}
