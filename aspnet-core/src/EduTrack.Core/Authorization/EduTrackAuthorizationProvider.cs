using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace EduTrack.Authorization;

public class EduTrackAuthorizationProvider : AuthorizationProvider
{
    public override void SetPermissions(IPermissionDefinitionContext context)
    {
        var fields = typeof(PermissionNames)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
            .Select(f => f.GetValue(null).ToString())
            .ToList();

        var parents = fields.Where(p => p.Count(c => c == '.') == 1);

        foreach (var parent in parents)
        {
            if (parent == PermissionNames.Pages_Tenants)
            {
                context.CreatePermission(parent, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            }
            else {
                var parentPermission = context.CreatePermission(parent, L(parent));

                var children = fields.Where(p => p.StartsWith(parent + "."));

                foreach (var child in children)
                {
                    parentPermission.CreateChildPermission(child, L(child));
                }
            }
        }

        //context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
        //context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
        //context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
        //context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
    }

    private static ILocalizableString L(string name)
    {
        return new LocalizableString(name, EduTrackConsts.LocalizationSourceName);
    }
}
