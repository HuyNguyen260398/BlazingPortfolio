namespace API.Endpoints;

public class UserEndpoints : IEndpoint
{
    private readonly IUserController _userController;

    public UserEndpoints(IUserController userController)
    {
        _userController = userController;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", async () => await _userController.GetUser()).WithTags("User");
        app.MapPut("/api/users", async (UserDto userDto) => await _userController.Update(userDto)).WithTags("User");
    }
}
