namespace API.Controllers;

public class ServiceController : BaseController<ServiceDto>, IServiceController
{
    private readonly IServiceRepo _serviceRepo;

    public ServiceController(IServiceRepo serviceRepo) : base(serviceRepo)
    {
        _serviceRepo = serviceRepo;
    }
}
