using Abp.Authorization;
using EduTrack.Authorization.Roles;
using EduTrack.Authorization.Users;

namespace EduTrack.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
