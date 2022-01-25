namespace API;

public static class ApiConfigs
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/User", GetUser);
    }

    private static async Task<IResult> GetUser(IUserRepo userRepo, IMapper mapper)
    {
        try
        {
            return Results.Ok(mapper.Map<UserDto>(await userRepo.GetUser()));
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}
