namespace WASM.Interfaces;

public interface IUserRepo : IBaseRepo<UserDto>
{
    Task<UserDto> GetUserAsync(string url);
}
