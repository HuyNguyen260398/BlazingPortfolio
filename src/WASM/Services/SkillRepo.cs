namespace WASM.Services;

public class SkillRepo : BaseRepo<SkillDto>, ISkillRepo
{
    private readonly HttpClient _httpClient;

    public SkillRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
