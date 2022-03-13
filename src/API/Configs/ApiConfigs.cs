namespace API.Configs;

public static class ApiConfigs
{
    public static void MapEndpoints(this WebApplication builder)
    {
        foreach (IEndpoint service in builder.Services.CreateScope().ServiceProvider.GetServices<IEndpoint>())
        {
            service.AddRoute(builder);
        }
    }
}
