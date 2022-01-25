namespace API;

public static class ApiConfigs
{
    public static void ConfigureApi(this WebApplication app)
    {
        // User Api
        app.MapGet("/Users", GetUser);
        app.MapPut("/Users", UpdateUser);

        // Service Api
        app.MapGet("/Services", GetServices);
        app.MapGet("/Services/{id}", GetServiceById);
        app.MapPost("/Services", CreateService);
        app.MapPut("/Services", UpdateService);
        app.MapDelete("/Services/{id}", DeleteService);
    }

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

    private static async Task<IResult> GetServices(IServiceRepo serviceRepo, IMapper mapper)
    {
        try
        {
            return Results.Ok(mapper.Map<List<ServiceDto>>(await serviceRepo.GetAllAsync()));
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> GetServiceById(int id, IServiceRepo serviceRepo, IMapper mapper)
    {
        try
        {
            var service = await serviceRepo.GetByIdAsync(id);

            if (service == null)
                return Results.NotFound();

            return Results.Ok(service);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> CreateService(ServiceDto serviceDtoToCreate, IServiceRepo serviceRepo, IMapper mapper)
    {
        try
        {
            var isCreateSuccess = await serviceRepo.CreateAsync(mapper.Map<Service>(serviceDtoToCreate));

            if (!isCreateSuccess)
                return Results.Problem();

            return Results.Created("CreateService", serviceDtoToCreate);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> UpdateService(ServiceDto serviceDtoToUpdate, IServiceRepo serviceRepo, IMapper mapper)
    {
        try
        {
            var isUpdateSuccess = await serviceRepo.UpdateAsync(mapper.Map<Service>(serviceDtoToUpdate));

            if (!isUpdateSuccess)
                return Results.Problem();

            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> DeleteService(int id, IServiceRepo serviceRepo, IMapper mapper)
    {
        try
        {
            var isDeleteSuccesss = await serviceRepo.DeleteAsync(id);

            if (!isDeleteSuccesss)
                return Results.Problem();

            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}
