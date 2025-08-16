using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductAttributeMappingConfiguration : IEntityTypeConfiguration<tProductAttributeMapping>
    {
        public void Configure(EntityTypeBuilder<tProductAttributeMapping> builder)
        {
            builder.HasKey(p => p.kProductAttributeMappingId); 

            builder.HasOne(p => p.tProduct)
                .WithMany()  
                .HasForeignKey(p => p.kProductId)
                .OnDelete(DeleteBehavior.SetNull);  

            builder.HasOne(p => p.tAttributeValue)
                .WithMany()  
                .HasForeignKey(p => p.kAttributeValueId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
