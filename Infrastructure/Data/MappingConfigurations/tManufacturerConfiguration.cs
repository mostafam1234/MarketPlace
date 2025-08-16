using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tManufacturerConfiguration : IEntityTypeConfiguration<tManufacturer>
    {
        public void Configure(EntityTypeBuilder<tManufacturer> builder)
        {
            builder.HasKey(a => a.kManufacturerId);
            builder.HasMany(a=>a.tProducts)
                .WithOne(a=>a.kManufacturer)
                .HasForeignKey(a=>a.kManufacturerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
