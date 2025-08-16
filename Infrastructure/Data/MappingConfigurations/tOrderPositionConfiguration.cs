using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tOrderPositionConfiguration : IEntityTypeConfiguration<tOrderPosition>
    {
        public void Configure(EntityTypeBuilder<tOrderPosition> builder)
        {
            builder.HasKey(o=>o.kOrderPositionId);
            builder.HasOne(o => o.kOrder)
                .WithMany()
                .HasForeignKey(o => o.kOrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.kVariant)
               .WithMany()
               .HasForeignKey(o => o.kVariantId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
