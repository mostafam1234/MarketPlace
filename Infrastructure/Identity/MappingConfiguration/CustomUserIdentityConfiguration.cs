using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.MappingConfiguration
{
    public class CustomUserIdentityConfiguration : IEntityTypeConfiguration<CustomUserIdentity>
    {
        public void Configure(EntityTypeBuilder<CustomUserIdentity> builder)
        {
            builder.HasOne(U => U.TenantInfo)
                .WithOne(A => A.UserIdentity)
                .HasForeignKey<TenantInfo>(A => A.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
