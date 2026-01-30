using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EduTrack.Authorization;

namespace EduTrack;

[DependsOn(
    typeof(EduTrackCoreModule),
    typeof(AbpAutoMapperModule))]
public class EduTrackApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<EduTrackAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(EduTrackApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
