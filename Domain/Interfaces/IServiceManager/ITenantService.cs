using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServiceManager
{
    public interface ITenantService
    {
        string Tenant { get; }

        void SetTenant(string tenant);

        string[] GetTenants();


    }
}
