namespace Infrastructure.Data.MappingConfigurations
{
    public class tShopifyAccountConfiguration : IEntityTypeConfiguration<tShopifyAccount>
    {
        public void Configure(EntityTypeBuilder<tShopifyAccount> builder)
        {
           builder.HasKey(s=>s.Id);
            builder.HasOne(s=>s.MarketplaceType)
                 .WithMany(m => m.tShopifyAccounts) 
                   .HasForeignKey(s => s.MarketplaceTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
