using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EduTrack.Controllers
{
    public abstract class EduTrackControllerBase : AbpController
    {
        protected EduTrackControllerBase()
        {
            LocalizationSourceName = EduTrackConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
