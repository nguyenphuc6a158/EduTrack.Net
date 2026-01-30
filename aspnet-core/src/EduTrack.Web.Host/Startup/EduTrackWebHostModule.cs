using Abp.Modules;
using Abp.Reflection.Extensions;
using EduTrack.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace EduTrack.Web.Host.Startup
{
    [DependsOn(
       typeof(EduTrackWebCoreModule))]
    public class EduTrackWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EduTrackWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EduTrackWebHostModule).GetAssembly());
        }
    }
}
