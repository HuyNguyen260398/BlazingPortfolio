namespace WASM.Services;

public class ArchievementRepo : BaseRepo<ArchievementDto>, IArchievementRepo
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public ArchievementRepo(HttpClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }
}
