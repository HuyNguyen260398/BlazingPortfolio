namespace API.Configs;

public static class ApiConfigs
{
    private static IServiceControllers _serviceControllers;

    public static void InitDIContainer(IServiceControllers serviceControllers)
    {
        _serviceControllers = serviceControllers;
    }

    public static void ConfigureApi(this WebApplication app)
    {
        // User Api
        app.MapGet("/Users", GetUser);
        app.MapPut("/Users", UpdateUser);

        // Service Api
        app.MapGet("/Services", async () => await _serviceControllers.GetAll());
        app.MapGet("/Services/{id}", async (int id) => await _serviceControllers.GetById(id));
        app.MapPost("/Services", async (ServiceDto serviceDto) => await _serviceControllers.Create(serviceDto));
        app.MapPut("/Services", async (ServiceDto serviceDto) => await _serviceControllers.Update(serviceDto));
        app.MapDelete("/Services/{id}", async (int id) => await _serviceControllers.Delete(id));
    }

    #region User

    private static async Task<IResult> GetUser(IUserRepo userRepo, IMapper mapper)
    {
        try
        {
            var user = mapper.Map<UserDto>(await userRepo.GetUser());

            if (user == null)
                return Results.NotFound();

            return Results.Ok(user);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserDto userDtoToUpdate, IUserRepo userRepo, IMapper mapper)
    {
        try
        {
            var isUpdateSuccess = await userRepo.UpdateAsync(mapper.Map<User>(userDtoToUpdate));

            if (!isUpdateSuccess)
                return Results.Problem();

            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    #endregion
}
