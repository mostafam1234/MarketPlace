namespace Infrastructure.Data.MappingConfigurations
{
    public class tEbayAccountConfiguration : IEntityTypeConfiguration<tEbayAccount>
    {
        public void Configure(EntityTypeBuilder<tEbayAccount> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.MarketplaceType)
                    .WithMany(m => m.tEbayAccounts)
                    .HasForeignKey(e => e.MarketplaceTypeId)
                    .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
