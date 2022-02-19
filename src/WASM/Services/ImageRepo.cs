using System.Text.RegularExpressions;

namespace WASM.Services;

public class ImageRepo : BaseRepo<ImageDto>, IImageRepo
{
    private readonly HttpClient _httpClient;

    public ImageRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
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
}
