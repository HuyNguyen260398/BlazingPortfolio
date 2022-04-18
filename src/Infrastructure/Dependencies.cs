namespace Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        //services.AddDbContext<AppDbContext>(options =>
        //    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
        //           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.Configure<DbSettings>(configuration.GetSection("MongoConnection"));

        services.AddSingleton<MongoContext>();

        services.AddScoped<IMongoDataService, MongoDataService>();
    }
}
