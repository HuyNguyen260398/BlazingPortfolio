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
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddSingleton<IUserRepo, UserInMemRepo>();
builder.Services.AddSingleton<IServiceRepo, ServiceInMemRepo>();
builder.Services.AddSingleton<IImageRepo, ImageInMemRepo>();
builder.Services.AddSingleton<IArchievementRepo, ArchievementInMemRepo>();
builder.Services.AddSingleton<IPostRepo, PostInMemRepo>();

builder.Services.AddSingleton<IUserController, UserController>();
builder.Services.AddSingleton<IServiceController, ServiceController>();
builder.Services.AddSingleton<IImageController, ImageController>();
builder.Services.AddSingleton<IArchievementController, ArchievementController>();
builder.Services.AddSingleton<IPostController, PostController>();

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

app.UseAuthentication();
app.UseAuthorization();

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

// Login
app.MapPost("/login", [AllowAnonymous] async (ITokenService tokenService, IUserRepo userRepo) =>
{
    // Todo: Separate this into a controller.

    var userDto = await userRepo.GetUserAsync(); // Todo: Update User and UserDto for login with username and password.

    if (userDto == null)
        return Results.NotFound();

    var token = await tokenService.BuildToken(
        builder.Configuration["Jwt:Key"], 
        builder.Configuration["Jwt:Issuer"], 
        builder.Configuration["Jwt:Audience"], 
        userDto);

    return Results.Ok(token);
})
.Produces(StatusCodes.Status200OK)
.WithName("Login")
.WithTags("Accounts");

app.MapGet("/AuthorizedResource", () => "Action Succeeded")
.Produces(StatusCodes.Status200OK)
.WithName("Authorized")
.WithTags("Accounts")
.RequireAuthorization();

app.Run();