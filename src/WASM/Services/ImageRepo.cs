namespace WASM.Services;

public class ImageRepo : BaseRepo<ImageDto>, IImageRepo
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public ImageRepo(HttpClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public async Task<string> SaveImageAsync(string url, ImageDto image)
    {
        try
        {
            if (image == null)
                return "";

            var response = await _httpClient.PostAsJsonAsync<ImageDto>(url, image);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var imgPath = await response.Content.ReadAsStringAsync();

                // Work around for getting img path from ReadAsStringAsync() issue
                var correctImgPath = Regex.Replace(imgPath, @"[^0-9a-zA-Z./-]+", "");
                return correctImgPath;
            }
        }
        catch (Exception)
        {
            return "";
        }
        return "";
    }

    public async Task<bool> RemoveImageAsync(string url, string guid)
    {
        try
        {
            if (String.IsNullOrEmpty(guid))
                return false;

            var response = await _httpClient.DeleteAsync($"{url}/{guid}");

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;
        }
        catch (Exception)
        {
            return false;
        }
        return false;
    }
}
