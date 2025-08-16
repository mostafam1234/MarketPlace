using Domain.Entities.Data;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductMarketplaceConfiguration : IEntityTypeConfiguration<tProductMarketplace>
    {
        public void Configure(EntityTypeBuilder<tProductMarketplace> builder)
        {
            builder.HasKey(v => new { v.ProductId, v.MarketplaceTypeId });
            builder.HasOne(v => v.Product)
                .WithMany(v=>v.ProductMarketplaces)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(vm => vm.MarketplaceType)
               .WithMany(mt => mt.ProductMarketplaces)
               .HasForeignKey(vm => vm.MarketplaceTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
