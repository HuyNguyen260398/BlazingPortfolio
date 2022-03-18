namespace WASM.Services;

public class SkillRepo : BaseRepo<SkillDto>, ISkillRepo
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public SkillRepo(HttpClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }
}
