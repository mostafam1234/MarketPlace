using Domain.Interfaces.IServiceManager;
using Microsoft.Extensions.Configuration;

namespace Marketplace.API.MiddleWare
{
    public class UserSessionProvider:IUserSessionProvider
    {
        private readonly UserSession _userSession;

        public UserSessionProvider(UserSession userSession)
        {
            _userSession = userSession;
        }

        public int UserId => _userSession.UserId;
        public int TenantId => _userSession.TenantId;
        public string Email => _userSession.Email;
        public string Role => _userSession.Role;

    }
}
