namespace API.Controllers;

public class ServiceControllers : BaseControllers<ServiceDto>, IServiceControllers
{
    private readonly IServiceRepo _serviceRepo;

    public ServiceControllers(IServiceRepo serviceRepo) : base(serviceRepo)
    {
        _serviceRepo = serviceRepo;
    }
}
