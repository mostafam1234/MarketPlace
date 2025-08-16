using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Identity.MappingConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityContext:IdentityDbContext<CustomUserIdentity,IdentityRole<int>,int>,IIdentityContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            :base(options)
        {
            
        }

        public DbSet<CustomUserIdentity> customUserIdentities { get; set; }
        public DbSet<TenantInfo> tenantInfo { get ; set ; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomUserIdentityConfiguration());
            builder.ApplyConfiguration(new TenantInfoConfiguration());
        }
    }
}
