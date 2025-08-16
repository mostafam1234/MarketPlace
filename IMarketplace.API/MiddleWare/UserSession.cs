using Domain.Interfaces.IServiceManager;

namespace Marketplace.API.MiddleWare
{
    public class UserSession
    {
        public int UserId { get; set; }
        public int TenantId {  get; set; }
        public string Email {  get; set; }
        public string Role {  get; set; }
    }
}
