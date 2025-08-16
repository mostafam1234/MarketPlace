using CoreSystem.DAL.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductStockConfiguration : IEntityTypeConfiguration<tProductStock>
    {
        public void Configure(EntityTypeBuilder<tProductStock> builder)
        {
            builder.HasKey(p => p.kProductStockId);
            builder.HasOne(p => p.kProductVariant)
                .WithMany()
                .HasForeignKey(p => p.kProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
