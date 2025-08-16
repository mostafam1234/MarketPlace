namespace Infrastructure.Data.MappingConfigurations
{
    public class tOdooAccountConfiguration : IEntityTypeConfiguration<tOdooAccount>
    {
        public void Configure(EntityTypeBuilder<tOdooAccount> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.kMarketplaceType)
                .WithMany(m => m.tOdooAccounts)
                .HasForeignKey(e => e.kMarketplaceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
