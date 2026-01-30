using EduTrack.Configuration.Dto;
using System.Threading.Tasks;

namespace EduTrack.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
