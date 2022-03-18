namespace WASM.Services;

public class ServiceRepo : BaseRepo<ServiceDto>, IServiceRepo
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public ServiceRepo(HttpClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }
}
