using Domain.Interfaces;
using Domain.Interfaces.IServiceManager;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TenantProvider
    {
        private readonly IUserSessionProvider userSessionProvider;
        private readonly IdentityContext identityContext;

        public TenantProvider(IUserSessionProvider userSessionProvider, IdentityContext identityContext)
        {
            this.userSessionProvider = userSessionProvider;
            this.identityContext = identityContext;
        }

        public async Task<string> GetConnectionString()
        {
            var userId = userSessionProvider.UserId;
            var connectionsting = await identityContext.tenantInfo
                .Where(x=>x.UserId==userId)
                .Select(x=>x.ConnectionString)
                .FirstOrDefaultAsync();

            return connectionsting??"";
        }
    }
}
