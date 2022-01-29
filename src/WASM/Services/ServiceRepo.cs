namespace WASM.Services;

public class ServiceRepo : BaseRepo<ServiceDto>, IServiceRepo
{
    private readonly HttpClient _httpClient;

    public ServiceRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
