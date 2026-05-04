using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.StudentAssignments.Dtos
{
    public class DatailDoHomeWorkDto
    {
        public List<int> Series { get; set; }
        public float AvgScore { get; set; }
        public float AvgScoreImprovement { get; set; }
        public float AvgScoreCurrentMonth { get; set; }
        public float CompletedCurrentMonthRate { get; set; }
        public float CompletedPreviousMonthRate { get; set; }
    }
}
