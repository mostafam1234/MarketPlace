using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tResponsiblePersonGPSRConfiguration : IEntityTypeConfiguration<tResponsiblePersonGPSR>
    {
        public void Configure(EntityTypeBuilder<tResponsiblePersonGPSR> builder)
        {
            builder.HasKey(s=>s.kResponsiblePersonGPSRId);
            builder.HasMany(s => s.tProducts)
                .WithOne(s => s.kResponsiblePersonGPSR)
                .HasForeignKey(s => s.kResponsiblePersonGPSRId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
