namespace Infrastructure.Data.MappingConfigurations
{
    public class tAmazonAccountConfiguration : IEntityTypeConfiguration<tAmazonAccount>
    {
        public void Configure(EntityTypeBuilder<tAmazonAccount> builder)
        {
            builder.HasKey(a => a.Id); 
            builder.HasOne(a=>a.MarketPlaceType)
                .WithMany(m=>m.tAmazonAccounts)
                .HasForeignKey(a=>a.MarketPlaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

                
        }
    }
}
