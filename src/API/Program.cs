var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton<IUserRepo, UserInMemRepo>();
builder.Services.AddSingleton<IServiceRepo, ServiceInMemRepo>();
builder.Services.AddSingleton<IArchievementRepo, ArchievementInMemRepo>();

builder.Services.AddScoped<IUserController, UserController>();
builder.Services.AddScoped<IServiceController, ServiceController>();
builder.Services.AddScoped<IArchievementController, ArchievementController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var serviceScope = app.Services.CreateScope())
{
    var userController = serviceScope.ServiceProvider.GetRequiredService<IUserController>();
    var serviceController = serviceScope.ServiceProvider.GetRequiredService<IServiceController>();
    var archievementController = serviceScope.ServiceProvider.GetRequiredService<IArchievementController>();

    ApiConfigs.InitDIContainer(
        userController,
        serviceController,
        archievementController);
}

app.ConfigureApi();

app.Run();