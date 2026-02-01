using System.ComponentModel.DataAnnotations;

namespace EduTrack.GradeLevels.Dto
{
    public class CreateGradeLevelInput
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
