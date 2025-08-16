using Application.Services.Auth.Commands;
using Domain.Entities.Identity;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.API.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<CustomUserIdentity, IdentityRole<int>>(identityOptions =>
            {
                identityOptions.SignIn.RequireConfirmedAccount = true;
                identityOptions.SignIn.RequireConfirmedEmail = true;
                identityOptions.SignIn.RequireConfirmedPhoneNumber = true;


                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequiredUniqueChars = 2;
                identityOptions.Password.RequiredLength = 6;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;

                identityOptions.Lockout.AllowedForNewUsers = true;
                identityOptions.Lockout.MaxFailedAccessAttempts = 10;

                //identityOptions.ClaimsIdentity

            })
    .AddEntityFrameworkStores<IdentityContext>()
       .AddDefaultTokenProviders();
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            return services;
}
    }
}
