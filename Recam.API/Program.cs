using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Recam.Models.Entities;
using Recam.Common;
using Recam.DataAccess.Data;
using Recam.Services;
using Recam.Services.Interfaces;
using Recam.Services.Services;
using Recam.API.Data;

using FluentValidation;
using FluentValidation.AspNetCore;
using Recam.Services.Validators;
using Recam.Services.Mappings;
using Recam.Repository.Interfaces;
using Recam.Repository.Repositories;
using Recam.Service.Interfaces;
using Recam.Service.Services;
using Recam.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// JWT settings
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);


// ============================
// CORS
// ============================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// ============================
// Database
// ============================

builder.Services.AddDbContext<RecamDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// ============================
// Identity
// ============================

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<RecamDbContext>()
    .AddDefaultTokenProviders();


// ============================
// JWT Authentication
// ============================

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


// ============================
// MongoDB
// ============================

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<MongoDbService>();




// ============================
// Controllers
// ============================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();

builder.Services.AddAutoMapper(typeof(AuthMappingProfile));

builder.Services.AddScoped<IMediaStorageService, LocalMediaStorageService>();

builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICaseContactRepository, CaseContactRepository>();
builder.Services.AddScoped<ICaseContactService, CaseContactService>();

builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAgentService, AgentService>();

// ============================
// Swagger
// ============================

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Recam API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter JWT token: {your token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
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
            Array.Empty<string>()
        }
    });
});


// ============================
// Services
// ============================

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtTokenService>();


var app = builder.Build();


// ============================
// Middleware
// ============================

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));


// ============================
// Seed Roles
// ============================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    await RoleSeeder.SeedRolesAsync(roleManager);
    await UserSeeder.SeedUsersAsync(userManager, roleManager);


    // var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // var user = await userManager.FindByEmailAsync("123123@gmail.com");

    // if (user != null)
    // {
    //     await userManager.AddToRoleAsync(user, "Admin");
    // }
}

app.Run();