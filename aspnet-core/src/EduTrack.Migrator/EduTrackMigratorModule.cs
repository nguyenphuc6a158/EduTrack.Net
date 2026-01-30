using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EduTrack.Configuration;
using EduTrack.EntityFrameworkCore;
using EduTrack.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace EduTrack.Migrator;

[DependsOn(typeof(EduTrackEntityFrameworkModule))]
public class EduTrackMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public EduTrackMigratorModule(EduTrackEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(EduTrackMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            EduTrackConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(EduTrackMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
