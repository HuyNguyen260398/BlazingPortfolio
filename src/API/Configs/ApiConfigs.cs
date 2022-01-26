namespace API.Configs;

public static class ApiConfigs
{
    private static IUserController _userController;
    private static IServiceController _serviceController;
    private static IArchievementController _archievementController;

    public static void InitDIContainer(
        IUserController userController,
        IServiceController serviceController,
        IArchievementController archievementController)
    {
        _userController = userController;
        _serviceController = serviceController;
        _archievementController = archievementController;
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

        // Archievement Api
        app.MapGet("/Archievements", async () => await _archievementController.GetAll());
        app.MapGet("/Archievements/{id}", async (int id) => await _archievementController.GetById(id));
        app.MapPost("/Archievements", async (ArchievementDto archievementDto) => await _archievementController.Create(archievementDto));
        app.MapPut("/Archievements", async (ArchievementDto archievementDto) => await _archievementController.Update(archievementDto));
        app.MapDelete("/Archievements/{id}", async (int id) => await _archievementController.Delete(id));
    }
}
