namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductImageMappingConfiguration : IEntityTypeConfiguration<tProductImageMapping>
    {
        public void Configure(EntityTypeBuilder<tProductImageMapping> builder)
        {
            builder.HasKey(pi=>pi.kProductImageMappingId);
            builder.HasOne(pi => pi.kProductImage)
                .WithMany()
                .HasForeignKey(pi => pi.kProductImageId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(pi => pi.kProductImage).WithMany()
                .HasForeignKey(pi=>pi.kProductId)
                .OnDelete(DeleteBehavior.SetNull);
            //not completed =>productID
        }
    }
}
