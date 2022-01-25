namespace API;

public class ServiceControllers : BaseControllers<ServiceDto>, IServiceControllers
{
    private readonly IServiceRepo _serviceRepo;

    public ServiceControllers(IServiceRepo serviceRepo) : base(serviceRepo)
    {
        _serviceRepo = serviceRepo;
    }
}
