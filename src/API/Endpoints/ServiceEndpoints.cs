namespace API.Endpoints;

public class ServiceEndpoints : IEndpoint
{
    private readonly IServiceController _serviceController;

    public ServiceEndpoints(IServiceController serviceController)
    {
        _serviceController = serviceController;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services", async () => await _serviceController.GetAll()).WithTags("Service");
        app.MapGet("/api/services/{id}", async (int id) => await _serviceController.GetById(id)).WithTags("Service");
        app.MapPost("/api/services", async (ServiceDto serviceDto) => await _serviceController.Create(serviceDto)).WithTags("Service");
        app.MapPut("/api/services", async (ServiceDto serviceDto) => await _serviceController.Update(serviceDto)).WithTags("Service");
        app.MapDelete("/api/services/{id}", async (int id) => await _serviceController.Delete(id)).WithTags("Service");
    }
}
