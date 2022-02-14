namespace WASM.Services;

public class ArchievementRepo : BaseRepo<ArchievementDto>, IArchievementRepo
{
    private readonly HttpClient _httpClient;

    public ArchievementRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
