using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServiceManager
{
    public interface IUserSessionProvider
    {
        int UserId { get; }
        int TenantId {  get; }
        string Email {  get; }
        string Role {  get; }

    }
}
