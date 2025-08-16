using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.MappingConfiguration
{
    public class TenantInfoConfiguration : IEntityTypeConfiguration<TenantInfo>
    {
        public void Configure(EntityTypeBuilder<TenantInfo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.UserIdentity)
                 .WithOne(u => u.TenantInfo)
                 .HasForeignKey<TenantInfo>(t => t.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}