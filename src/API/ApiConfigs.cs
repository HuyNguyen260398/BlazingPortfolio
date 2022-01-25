namespace API;

public static class ApiConfigs
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/User", GetUser);
        app.MapPut("/User", UpdateUser);
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

    private static async Task<IResult> UpdateUser(IUserRepo userRepo, UserDto userDtoToUpdate, IMapper mapper)
    {
        try
        {
            await userRepo.UpdateAsync(mapper.Map<User>(userDtoToUpdate));
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}
