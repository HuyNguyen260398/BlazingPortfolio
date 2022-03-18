namespace WASM.Services;

public class UserRepo : BaseRepo<UserDto>, IUserRepo
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public UserRepo(HttpClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public async Task<UserDto> GetUserAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<UserDto>(url);
            return response;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
