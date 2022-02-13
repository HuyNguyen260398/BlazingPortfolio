namespace API.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        foreach (Type item in from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
                              where t.GetInterfaces().Contains(typeof(IEndpoint))
                              where !t.IsInterface
                              select t)
        {
            services.AddScoped(typeof(IEndpoint), item);
        }

        return services;
    }
}
