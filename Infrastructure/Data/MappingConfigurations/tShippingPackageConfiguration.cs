namespace Infrastructure.Data.MappingConfigurations
{
    public class tShippingPackageConfiguration : IEntityTypeConfiguration<tShippingPackage>
    {
        public void Configure(EntityTypeBuilder<tShippingPackage> builder)
        {
            builder.HasKey(s=>s.kShippingPackageId);
            builder.HasOne(s=>s.kOrder)
                .WithMany()
                .HasForeignKey(s=>s.kOrderId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(s => s.kShippingMethod)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
