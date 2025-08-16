using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class CustomUserIdentityDbInitializer : ICustomUserIdentityDbInitializer  
    {
        private readonly IdentityContext _context;
        private readonly UserManager<CustomUserIdentity> _userManager;
        private readonly MarketPlaceContext marketPlaceContext;

        public CustomUserIdentityDbInitializer(IdentityContext context,
                                               UserManager<CustomUserIdentity> userManager,
                                               MarketPlaceContext marketPlaceContext)
        {
            _context = context;
            _userManager = userManager;
            this.marketPlaceContext = marketPlaceContext;
        }

        public async Task InitializeAsync()
        {
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                await _context.Database.MigrateAsync();
        }

        public async Task InitializeAsyncForMarketPlace()
        {
            try
            {
                var pendingMigrations = await marketPlaceContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                    await marketPlaceContext.Database.MigrateAsync();
            }
            catch(Exception ex)
            {

            }
           
        }

        public async Task SeedAsync()
        {
            if (!await _userManager.Users.AnyAsync())  
            {
                var user = new CustomUserIdentity()
                {
                    DisplayName = "Alaa",
                    UserName = "Alaa.Abdo",
                    Email = "alaa.abdo@gmail.com",
                    PhoneNumber = "01090072486",
                };
                var result = await _userManager.CreateAsync(user, "P@sssssssWord21@#");
                if (result.Succeeded)
                {
                    Console.WriteLine("Success");

                  
                }


            }
        }
    }
}
