namespace WASM.Static;

internal static class ApiEndPoints
{
#if DEBUG
    internal const string ServerBaseUrl = "https://localhost:7054";
#else
    internal const string ServerBaseUrl = "";
#endif
    internal readonly static string UserEndpoint = $"{ServerBaseUrl}/api/categories";
}
