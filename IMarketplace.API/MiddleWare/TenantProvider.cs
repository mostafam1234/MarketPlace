using Domain.Interfaces;
using Domain.Interfaces.IServiceManager;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Marketplace.API.MiddleWare
{
    public class TenantProvider:ITenantProvider
    {
        private readonly IUserSessionProvider _userSessionProvider;
        private readonly IIdentityContext _iidentityContext;

        public TenantProvider( IUserSessionProvider userSessionProvider
            , IIdentityContext iidentityContext)
        {
            _userSessionProvider = userSessionProvider;
            _iidentityContext = iidentityContext;
        }

        public async Task<string> getConnectionString()
        {
            var tenantId = _userSessionProvider.TenantId;


            var connectionString = await _iidentityContext.tenantInfo
                                    .Where(t => t.Id == tenantId)
                                    .Select(t => t.ConnectionString)
                                    .FirstOrDefaultAsync();
            return connectionString;

        }
    }
}
