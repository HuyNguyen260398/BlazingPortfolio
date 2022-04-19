var builder = WebApplication.CreateBuilder(args);

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JOSN Web Token based security"
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        Array.Empty<string>()
    }
};

var contact = new OpenApiContact()
{
    Name = "Huy Nguyen",
    Email = "huynguyen260398@gmail.com",
    Url = new Uri("http://www.huynguyen.com")
};

var license = new OpenApiLicense()
{
    Name = "Free License",
    Url = new Uri("http://www.huynguyen.com")
};

var info = new OpenApiInfo()
{
    Version = "V1",
    Title = "Minimal API - JWT Auth",
    Description = "Implement JWT Auth in Minimal API",
    TermsOfService = new Uri("http://www.huynguyen.com"),
    Contact = contact,
    License = license
};

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Cors Policy
builder.Services.AddCors(o =>
{
    o.AddPolicy(name: myAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("https://localhost:7035",
                                               "https://blazingporfoliowasm.azurewebsites.net")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
});

builder.Services.AddAutoMapper(typeof(Mapping));

Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});

// Add JWT Config
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IArchievementRepo, ArchievementMongoRepo>();
builder.Services.AddScoped<IImageRepo, ImageMongoRepo>();
builder.Services.AddScoped<IPostRepo, PostMongoRepo>();
builder.Services.AddScoped<IServiceRepo, ServiceMongoRepo>();
builder.Services.AddScoped<ISkillRepo, SkillMongoRepo>();
builder.Services.AddScoped<IUserRepo, UserMongoRepo>();

//builder.Services.AddScoped<IArchievementRepo, ArchievementRepo>();
//builder.Services.AddScoped<IImageRepo, ImageRepo>();
//builder.Services.AddScoped<IPostRepo, PostRepo>();
//builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
//builder.Services.AddScoped<ISkillRepo, SkillRepo>();
//builder.Services.AddScoped<IUserRepo, UserRepo>();

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

app.MapPost("api/users/login", [AllowAnonymous] async (UserDto authUser, IUserRepo userRepo) => {
    var user = await userRepo.GetUserAsync();

    if (authUser.Email == user.Email && authUser.Password == user.Password)
    {
        var secureKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey(secureKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("Id", "1"),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.Now.AddMinutes(15),
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = credentials
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return Results.Ok(jwtToken);
    }
    return Results.Unauthorized();
}).WithTags("User");

app.MapGet("/AuthorizedResource", [Authorize] () => "Action Succeeded");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();