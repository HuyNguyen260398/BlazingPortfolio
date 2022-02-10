var builder = WebApplication.CreateBuilder(args);

// Cors Policy
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton<IArchievementRepo, ArchievementRepo>();
builder.Services.AddSingleton<IImageRepo, ImageRepo>();
builder.Services.AddSingleton<IPostRepo, PostRepo>();
builder.Services.AddSingleton<IServiceRepo, ServiceRepo>();
builder.Services.AddSingleton<ISkillRepo, SkillRepo>();
builder.Services.AddSingleton<IUserRepo, UserRepo>();

builder.Services.AddScoped<IArchievementController, ArchievementController>();
builder.Services.AddScoped<IImageController, ImageController>();
builder.Services.AddScoped<IPostController, PostController>();
builder.Services.AddScoped<IServiceController, ServiceController>();
builder.Services.AddScoped<ISkillController, SkillController>();
builder.Services.AddScoped<IUserController, UserController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

using (var serviceScope = app.Services.CreateScope())
{
    var userController = serviceScope.ServiceProvider.GetRequiredService<IUserController>();
    var skillController = serviceScope.ServiceProvider.GetRequiredService<ISkillController>();
    var serviceController = serviceScope.ServiceProvider.GetRequiredService<IServiceController>();
    var imageController = serviceScope.ServiceProvider.GetRequiredService<IImageController>();
    var archievementController = serviceScope.ServiceProvider.GetRequiredService<IArchievementController>();
    var postController = serviceScope.ServiceProvider.GetRequiredService<IPostController>();

    ApiConfigs.InitDIContainer(
        userController,
        skillController,
        serviceController,
        imageController,
        archievementController,
        postController);
}

app.ConfigureApi();

app.Run();