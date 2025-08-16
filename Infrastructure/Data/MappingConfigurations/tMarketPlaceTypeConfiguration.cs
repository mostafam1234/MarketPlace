namespace Infrastructure.Data.MappingConfigurations
{
    public class tMarketPlaceTypeConfiguration : IEntityTypeConfiguration<tMarketplaceType>
    {
        public void Configure(EntityTypeBuilder<tMarketplaceType> builder)
        {
            builder.HasKey(m => m.kMarketplaceType);
            builder.HasMany(m => m.tAmazonAccounts)
               .WithOne(a => a.MarketPlaceType)
               .HasForeignKey(a => a.MarketPlaceTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.tKauflandAccounts)
                .WithOne(k => k.MarketPlaceType)
                .HasForeignKey(k => k.MarketPlaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

      

            builder.HasMany(m => m.tOdooAccounts)
                .WithOne(o => o.kMarketplaceType)
                .HasForeignKey(o => o.kMarketplaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.tEbayAccounts)
                .WithOne(e => e.MarketplaceType)
                .HasForeignKey(e => e.MarketplaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.tOttoAccounts)
                .WithOne(o => o.kMarketplace)
                .HasForeignKey(o => o.kMarketplaceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.tShopifyAccounts)
                .WithOne(s => s.MarketplaceType)
                .HasForeignKey(s => s.MarketplaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

        
            builder.HasMany(m => m.ProductMarketplaces)
                .WithOne(vm => vm.MarketplaceType)
                .HasForeignKey(vm => vm.MarketplaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
