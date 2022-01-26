namespace API.Configs;

public static class ApiConfigs
{
    private static IUserController _userController;
    private static IServiceController _serviceController;

    public static void InitDIContainer(
        IUserController userController,
        IServiceController serviceController)
    {
        _userController = userController;
        _serviceController = serviceController;
    }

    public static void ConfigureApi(this WebApplication app)
    {
        // User Api
        app.MapGet("/Users", async () => await _userController.GetUser());
        app.MapPut("/Users", async (UserDto userDto) => await _userController.Update(userDto));

        // Service Api
        app.MapGet("/Services", async () => await _serviceController.GetAll());
        app.MapGet("/Services/{id}", async (int id) => await _serviceController.GetById(id));
        app.MapPost("/Services", async (ServiceDto serviceDto) => await _serviceController.Create(serviceDto));
        app.MapPut("/Services", async (ServiceDto serviceDto) => await _serviceController.Update(serviceDto));
        app.MapDelete("/Services/{id}", async (int id) => await _serviceController.Delete(id));
    }
}
