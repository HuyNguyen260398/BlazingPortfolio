var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton<IUserRepo, UserInMemRepo>();
builder.Services.AddSingleton<IServiceRepo, ServiceInMemRepo>();

builder.Services.AddScoped<IServiceControllers, ServiceControllers>();

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
    var serviceControllers = serviceScope.ServiceProvider.GetRequiredService<IServiceControllers>();
    ApiConfigs.InitDIContainer(serviceControllers);
}

app.ConfigureApi();

app.Run();