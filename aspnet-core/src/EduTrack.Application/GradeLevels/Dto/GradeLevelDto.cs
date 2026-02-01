using Abp.Application.Services.Dto;

namespace EduTrack.GradeLevels.Dto
{
    public class GradeLevelDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
