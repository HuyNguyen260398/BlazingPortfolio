using Application.Interfaces;
using CoreBusiness.Models;

namespace Infrastructure.InMemDb;

public class ServiceInMemRepo : IServiceRepo
{
    private static List<Service> _services = new()
    {
        new Service { ServiceId = 1, Name = "Web Development", Description = "Building web apps with DotNet", SvgPath = String.Empty },
        new Service { ServiceId = 2, Name = "DevOps", Description = "Upscaling apps using DevOps stacks", SvgPath = String.Empty },
        new Service { ServiceId = 3, Name = "Data Analysist", Description = "Visualizing data by Power Bi", SvgPath = String.Empty }
    };

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await Task.FromResult(_services);
    }

    public async Task<Service> GetByIdAsync(int id)
    {
        return await Task.FromResult(_services.Find(s => s.ServiceId == id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_services.Any(s => s.ServiceId == id));
    }

    public async Task<bool> CreateAsync(Service serviceToCreate)
    {
        if (_services.Any(s => s.Name.Equals(serviceToCreate.Name, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_services != null && _services.Count > 0)
            serviceToCreate.ServiceId = _services.Max(s => s.ServiceId) + 1;
        else
            serviceToCreate.ServiceId = 1;

        _services.Add(serviceToCreate);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(Service serviceToUpdate)
    {
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
