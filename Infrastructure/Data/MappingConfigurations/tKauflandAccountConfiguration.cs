namespace Infrastructure.Data.MappingConfigurations
{
    public class tKauflandAccountConfiguration : IEntityTypeConfiguration<tKauflandAccount>
    {
        public void Configure(EntityTypeBuilder<tKauflandAccount> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(k => k.MarketPlaceType)
                   .WithMany(m => m.tKauflandAccounts)
                   .HasForeignKey(k => k.MarketPlaceTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
