namespace API.Interfaces;

public interface IUserController : IBaseController<UserDto>
{
    Task<IResult> GetUser();
}
