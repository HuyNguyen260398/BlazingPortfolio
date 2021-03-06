namespace Infrastructure.InMemDb;

public class ServiceInMemRepo : IServiceRepo
{

    private static List<Service> _services = new()
    {
        new Service 
        { 
            ServiceId = 1, 
            Name = "Web Developement", 
            Description = "Building web apps with DotNet", 
            DisplayIcon = "Icons.Filled.DesktopWindows"
        },
        new Service 
        { 
            ServiceId = 2, 
            Name = "DevOps", 
            Description = "Upscaling apps using DevOps stacks", 
            DisplayIcon = "Icons.Filled.CloudSync"
        },
        new Service 
        { 
            ServiceId = 3, 
            Name = "Data Analysist", 
            Description = "Visualizing data by Power Bi", 
            DisplayIcon = "Icons.Filled.QueryStats"
        }
    };

    private readonly IMapper _mapper;

    public ServiceInMemRepo(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<List<ServiceDto>>(_services));
    }

    public async Task<ServiceDto> GetByIdAsync(int id)
    {
        return await Task.FromResult(_mapper.Map<ServiceDto>(_services.Find(s => s.ServiceId == id)));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_services.Any(s => s.ServiceId == id));
    }

    public async Task<bool> CreateAsync(ServiceDto serviceDtoToCreate)
    {
        var serviceToCreate = _mapper.Map<Service>(serviceDtoToCreate);

        if (_services.Any(s => s.Name.Equals(serviceToCreate.Name, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_services != null && _services.Count > 0)
            serviceToCreate.ServiceId = _services.Max(s => s.ServiceId) + 1;
        else
            serviceToCreate.ServiceId = 1;

        _services.Add(serviceToCreate);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(ServiceDto serviceDtoToUpdate)
    {
        var serviceToUpdate = _mapper.Map<Service>(serviceDtoToUpdate);

        var index = _services.FindIndex(s => s.ServiceId == serviceToUpdate.ServiceId);

        if (index < 0)
            return await Task.FromResult(false);

        _services[index] = serviceToUpdate;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _services.FindIndex(s => s.ServiceId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _services.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
