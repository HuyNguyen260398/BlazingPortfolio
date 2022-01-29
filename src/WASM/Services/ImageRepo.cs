namespace WASM.Services;

public class ImageRepo : BaseRepo<ImageDto>, IImageRepo
{
    private readonly HttpClient _httpClient;

    public ImageRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }
}
