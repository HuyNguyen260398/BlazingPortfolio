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
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token * *_only_ * *",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // must be lower case
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] { }}
    });
});

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddAuthorization();
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

builder.Services.AddSingleton<ITokenService, TokenService>();

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
app.MapPost("/login", [AllowAnonymous] async (ITokenService tokenService, IUserRepo userRepo, HttpResponse response) =>
{
    // Todo: Separate this into a controller.

    var userDto = await userRepo.GetUserAsync(); // Todo: Update User and UserDto for login with username and password.

    if (userDto == null)
    {
        response.StatusCode = 401;
        return;
    }

    var token = tokenService.BuildToken(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"], builder.Configuration["Jwt:Audience"], userDto);

    await response.WriteAsJsonAsync(new { token = token });

    return;
})
.Produces(StatusCodes.Status200OK)
.WithName("Login")
.WithTags("Accounts");

app.MapGet("/AuthorizedResource", (Func<string>)(
    [Authorize] () => "Action Succeeded")
)
.Produces(StatusCodes.Status200OK)
.WithName("Authorized")
.WithTags("Accounts").RequireAuthorization();

app.Run();