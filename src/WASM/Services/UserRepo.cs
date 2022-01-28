using WASM.Interfaces;
using Application.Dtos;
using System.Net.Http.Json;

namespace WASM.Services;

public class UserRepo : BaseRepo<UserDto>, IUserRepo
{
    private readonly HttpClient _httpClient;

    public UserRepo(HttpClient httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
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
