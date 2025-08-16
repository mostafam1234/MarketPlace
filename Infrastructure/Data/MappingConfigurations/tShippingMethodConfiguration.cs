using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tShippingMethodConfiguration : IEntityTypeConfiguration<tShippingMethod>
    {
        public void Configure(EntityTypeBuilder<tShippingMethod> builder)
        {
            builder.HasKey(s=>s.kShippingMethodId);
            builder.HasMany(s=>s.tShippingPackages)
                .WithOne(s=>s.kShippingMethod)
                .HasForeignKey(s=>s.kShippingMethodId)
                .OnDelete(DeleteBehavior.SetNull);
          
        }
    }
}
