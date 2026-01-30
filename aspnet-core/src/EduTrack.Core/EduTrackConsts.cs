using EduTrack.Debugging;

namespace EduTrack;

public class EduTrackConsts
{
    public const string LocalizationSourceName = "EduTrack";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "1a0cbb2b4f5d4a27bb917875d4cd12ad";
}
