using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tVatTypeConfiguration : IEntityTypeConfiguration<tVatType>
    {
        public void Configure(EntityTypeBuilder<tVatType> builder)
        {
            builder.HasKey(v=>v.kVatType);
            builder.HasMany(v=>v.tProducts)
                .WithOne(v=>v.kVatTypeNavigation)
                .HasForeignKey(v=>v.kVatTypeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
