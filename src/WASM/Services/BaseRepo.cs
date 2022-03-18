namespace WASM.Services;

public class BaseRepo<T> : IBaseRepo<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    internal const string LocalStorageBearerKeyName = "BearerToken";
    internal const string JwtScheme = "Bearer";

    public BaseRepo(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public BaseRepo(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<T>>(url);
            return response;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<T> GetByIdAsync(string url, int id)
    {
        try
        {
            if (id < 1)
                return null;

            var response = await _httpClient.GetFromJsonAsync<T>($"{url}/{id}");
            return response;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> CreateAsync(string url, T obj)
    {
        try
        {
            if (obj == null)
                return false;

            string savedToken = await _localStorage.GetItemAsync<string>(LocalStorageBearerKeyName);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtScheme, savedToken);
            var response = await _httpClient.PostAsJsonAsync<T>(url, obj);

            if (response.StatusCode == HttpStatusCode.Created)
                return true;
        }
        catch (Exception)
        {
            return false;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(string url, T obj)
    {
        try
        {
            if (obj == null)
                return false;

            string savedToken = await _localStorage.GetItemAsync<string>(LocalStorageBearerKeyName);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtScheme, savedToken);
            var response = await _httpClient.PutAsJsonAsync<T>(url, obj);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;
        }
        catch (Exception)
        {
            return false;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(string url, int id)
    {
        try
        {
            if (id < 1)
                return false;

            string savedToken = await _localStorage.GetItemAsync<string>(LocalStorageBearerKeyName);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtScheme, savedToken);
            var response = await _httpClient.DeleteAsync($"{url}/{id}");

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
