using Abp.Domain.Entities;

namespace EduTrack.GradeLevels
{
    public class GradeLevel : Entity<int>
    {
        public string Name { get; protected set; }
        protected GradeLevel() { }
        public GradeLevel(string name)
        {
            Name = name;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
