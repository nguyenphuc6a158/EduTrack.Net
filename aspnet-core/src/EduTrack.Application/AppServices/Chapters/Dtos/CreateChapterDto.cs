using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.AppServices.Chapters.Dtos
{
    public class CreateChapterDto
    {
        public string ChapterName { get; set; }

        public long SubjectId { get; set; }
    }
}
