namespace WASM.Services;

public class PostRepo : BaseRepo<PostDto>, IPostRepo
{
    private readonly HttpClient _httpClient;

    public PostRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
