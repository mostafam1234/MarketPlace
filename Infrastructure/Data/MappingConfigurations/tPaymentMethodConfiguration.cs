using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tPaymentMethodConfiguration : IEntityTypeConfiguration<tPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<tPaymentMethod> builder)
        {
            builder.HasKey(p=>p.kPaymentMethodId);
            builder.HasMany(p=>p.tOrders)
                .WithOne(p=>p.kPaymentMethod)
                .HasForeignKey(p=>p.kPaymentMethodId)
                .OnDelete(DeleteBehavior.SetNull);
            
        }
    }
}
