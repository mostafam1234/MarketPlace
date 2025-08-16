using Application.Services.Auth.Commands;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Domain.Interfaces.IServiceManager;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Services;
using Marketplace.API.MiddleWare;
using Microsoft.AspNetCore.Identity;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataBase(builder.Configuration);

builder.Services.AddHttpContextAccessor();


builder.Services.AddIdentity<CustomUserIdentity, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
})
.AddEntityFrameworkStores<IdentityContext>()
.AddSignInManager();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme, opt =>
    {
        opt.BearerTokenExpiration = TimeSpan.FromMinutes(600);
        opt.RefreshTokenExpiration = TimeSpan.FromMinutes(43200);
    });

builder.Services.AddIdentityCore<CustomUserIdentity>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddSignInManager()
                .AddApiEndpoints();


builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<IUserSessionProvider, UserSessionProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SessionInfoMiddleWare>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{

    await SeedDefaultUsers(scope);
}

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
app.MapIdentityApi<CustomUserIdentity>();

app.MapControllers();

//using var scope = app.Services.CreateScope();
//var dbInitializer = scope.ServiceProvider.GetRequiredService<ICustomUserIdentityDbInitializer>();
//await dbInitializer.InitializeAsync();
//await dbInitializer.SeedAsync();

app.Run();
