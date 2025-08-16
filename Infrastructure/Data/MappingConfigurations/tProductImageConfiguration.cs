namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductImageConfiguration : IEntityTypeConfiguration<tProductImage>
    {
        public void Configure(EntityTypeBuilder<tProductImage> builder)
        {
            builder.HasKey(p => p.kProductImageId);
            builder.HasMany(p => p.tProductImageMappings)
                .WithOne(p => p.kProductImage)
                .HasForeignKey(p => p.kProductImageId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
