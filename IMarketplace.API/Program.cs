using Application.Services.Auth.Commands;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Domain.Interfaces.IServiceManager;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Services;
using Marketplace.API.MiddleWare;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddScoped<Infrastructure.Services.TenantProvider>();

builder.Services.AddHttpContextAccessor();

// Single Identity configuration
builder.Services.AddIdentity<CustomUserIdentity, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
})
.AddEntityFrameworkStores<IdentityContext>()
.AddSignInManager()
.AddApiEndpoints();

// JWT Bearer Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"] ?? "a-string-secret-at-least-256-bits-long"))
    };
    
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine($"Token validated successfully for user: {context.Principal?.Identity?.Name}");
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<IUserSessionProvider, UserSessionProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Log configuration for debugging
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application starting up...");
logger.LogInformation("JWT Issuer: {Issuer}", builder.Configuration["JwtSettings:Issuer"]);
logger.LogInformation("JWT Audience: {Audience}", builder.Configuration["JwtSettings:Audience"]);
logger.LogInformation("JWT Secret Key length: {KeyLength}", 
    builder.Configuration["JwtSettings:SecretKey"]?.Length ?? 0);

app.UseHttpsRedirection();

// Authentication must come before your custom middleware
logger.LogInformation("Setting up authentication middleware...");
app.UseAuthentication();
logger.LogInformation("Setting up authorization middleware...");
app.UseAuthorization();

// Your custom middleware runs after authentication
logger.LogInformation("Setting up custom session middleware...");
app.UseMiddleware<SessionInfoMiddleWare>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.Services.CreateScope())
//{
//    await SeedDefaultUsers(scope);
//}

async Task SeedDefaultUsers(IServiceScope scope)
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CustomUserIdentity>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

    // Ensure "Admin" role exists
    var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
    if (!adminRoleExists)
    {
        var roleResult = await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
        if (!roleResult.Succeeded)
        {
            throw new Exception($"Failed to create 'Admin' role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
        }
    }

    var defaultUser = await userManager.FindByNameAsync("Test201@gmail.com");
    if (defaultUser == null)
    {
        var user = CustomUserIdentity.Instance(
            "Test2",
            "Test201@gmail.com",
            "01023234232",
            "Host=localhost;Port=5432;Database=Middleware_db;Username=postgres;Password=kontesslord2"
        );

        var result = await userManager.CreateAsync(user.Value, "Password500$$");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user.Value, "Admin");
        }
        else
        {
            throw new Exception($"Failed to create default user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}

using var scope = app.Services.CreateScope();
var dbInitializer = scope.ServiceProvider.GetRequiredService<ICustomUserIdentityDbInitializer>();
await dbInitializer.InitializeAsync();
await dbInitializer.InitializeAsyncForMarketPlace();
await dbInitializer.SeedAsync();

app.MapControllers();

app.Run();
