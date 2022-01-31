var builder = WebApplication.CreateBuilder(args);

// Cors Policy
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Blazing Portfolio API",
        Description = "Web APIs for managing a portfolio webpage.",
        Version = "v1"
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
                {
                    c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
                    c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudience = builder.Configuration["Auth0:Audience"],
                        ValidIssuer = $"{builder.Configuration["Auth0:Domain"]}"
                    };
                });

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("read-write", p => p.
        RequireAuthenticatedUser().
        RequireClaim("scope", "read-write"));
});

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton<IUserRepo, UserInMemRepo>();
builder.Services.AddSingleton<IServiceRepo, ServiceInMemRepo>();
builder.Services.AddSingleton<IImageRepo, ImageInMemRepo>();
builder.Services.AddSingleton<IArchievementRepo, ArchievementInMemRepo>();
builder.Services.AddSingleton<IPostRepo, PostInMemRepo>();

builder.Services.AddScoped<IUserController, UserController>();
builder.Services.AddScoped<IServiceController, ServiceController>();
builder.Services.AddScoped<IImageController, ImageController>();
builder.Services.AddScoped<IArchievementController, ArchievementController>();
builder.Services.AddScoped<IPostController, PostController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.Use(async (ctx, next) =>
{
    try
    {
        await next();
    }
    catch (BadHttpRequestException ex)
    {
        ctx.Response.StatusCode = ex.StatusCode;

        await ctx.Response.WriteAsync(ex.Message);
    }
});

using (var serviceScope = app.Services.CreateScope())
{
    var userController = serviceScope.ServiceProvider.GetRequiredService<IUserController>();
    var serviceController = serviceScope.ServiceProvider.GetRequiredService<IServiceController>();
    var imageController = serviceScope.ServiceProvider.GetRequiredService<IImageController>();
    var archievementController = serviceScope.ServiceProvider.GetRequiredService<IArchievementController>();
    var postController = serviceScope.ServiceProvider.GetRequiredService<IPostController>();

    ApiConfigs.InitDIContainer(
        userController,
        serviceController,
        imageController,
        archievementController,
        postController);
}

app.ConfigureApi();

app.Run();