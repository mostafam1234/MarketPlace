namespace Infrastructure.Data.MappingConfigurations
{
    public class tOttoAccountConfiguration : IEntityTypeConfiguration<tOttoAccount>
    {
        public void Configure(EntityTypeBuilder<tOttoAccount> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.kMarketplace)
                .WithMany() 
                .HasForeignKey(o => o.kMarketplaceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        }
}
