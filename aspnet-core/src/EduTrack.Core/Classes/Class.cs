using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Classes
{
    public class Class : AuditedEntity<long>
    {
        public virtual string ClassName { get; set; }

        public virtual int Level { get; set; }
    }
}
