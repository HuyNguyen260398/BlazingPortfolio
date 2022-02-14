namespace WASM.Static;

internal static class ApiEndPoints
{
#if DEBUG
    internal const string ServerBaseUrl = "https://localhost:7007";
#else
    internal const string ServerBaseUrl = "";
#endif
    internal readonly static string ArchievementEndpoint = $"{ServerBaseUrl}/api/archievements";
    internal readonly static string ImageEndpoint = $"{ServerBaseUrl}/api/images";
    internal readonly static string PostEndpoint = $"{ServerBaseUrl}/api/posts";
    internal readonly static string ServiceEndpoint = $"{ServerBaseUrl}/api/services";
    internal readonly static string SkillEndpoint = $"{ServerBaseUrl}/api/skills";
    internal readonly static string UserEndpoint = $"{ServerBaseUrl}/api/users";
}
