namespace API.Controllers;

public class UserController : BaseController<UserDto>, IUserController
{
    private readonly IUserRepo _userRepo;

    public UserController(IUserRepo userRepo) : base(userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<IResult> GetUser()
    {
        try
        {
            var user = await _userRepo.GetUserAsync();

            if (user == null)
                return Results.NotFound();

            return Results.Ok(user);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}
