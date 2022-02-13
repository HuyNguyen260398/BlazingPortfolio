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

builder.Services.AddScoped<IArchievementRepo, ArchievementRepo>();
builder.Services.AddScoped<IImageRepo, ImageRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
builder.Services.AddScoped<ISkillRepo, SkillRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

//builder.Services.AddScoped<IArchievementRepo, ArchievementInMemRepo>();
//builder.Services.AddScoped<IImageRepo, ImageInMemRepo>();
//builder.Services.AddScoped<IPostRepo, PostInMemRepo>();
//builder.Services.AddScoped<IServiceRepo, ServiceInMemRepo>();
//builder.Services.AddScoped<ISkillRepo, SkillInMemRepo>();
//builder.Services.AddScoped<IUserRepo, UserInMemRepo>();

builder.Services.AddScoped<IArchievementController, ArchievementController>();
builder.Services.AddScoped<IImageController, ImageController>();
builder.Services.AddScoped<IPostController, PostController>();
builder.Services.AddScoped<IServiceController, ServiceController>();
builder.Services.AddScoped<ISkillController, SkillController>();
builder.Services.AddScoped<IUserController, UserController>();

builder.Services.AddEndpoints();

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

//using (var serviceScope = app.Services.CreateScope())
//{
//    var scopeProvider = serviceScope.ServiceProvider;

//    try
//    {
//        var userController = scopeProvider.GetRequiredService<IUserController>();
//        var skillController = scopeProvider.GetRequiredService<ISkillController>();
//        var serviceController = scopeProvider.GetRequiredService<IServiceController>();
//        var imageController = scopeProvider.GetRequiredService<IImageController>();
//        var archievementController = scopeProvider.GetRequiredService<IArchievementController>();
//        var postController = scopeProvider.GetRequiredService<IPostController>();

//        ApiConfigs.InitDIContainer(
//            userController,
//            skillController,
//            serviceController,
//            imageController,
//            archievementController,
//            postController);
//    }
//    catch (Exception)
//    {
//        throw;
//    }

//}

app.MapEndpoints();

app.Run();