using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIdentityContext
    {
        DbSet<CustomUserIdentity>  customUserIdentities { get; set; }
        DbSet<TenantInfo> tenantInfo { get; set; }  
    }
}
