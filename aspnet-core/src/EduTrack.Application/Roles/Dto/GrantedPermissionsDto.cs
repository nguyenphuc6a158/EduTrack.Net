using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Roles.Dto
{
    public class GrantedPermissionsDto
    {
        public Dictionary<string, bool> grantedPermissionNames { get; set; }
    }
}
