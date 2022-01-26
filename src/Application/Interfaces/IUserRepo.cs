namespace Application.Interfaces;

public interface IUserRepo : IBaseRepo<UserDto>
{
    Task<UserDto> GetUserAsync();
}
