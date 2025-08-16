namespace Infrastructure.Data.MappingConfigurations
{
    public class tSupplierConfiguration : IEntityTypeConfiguration<tSupplier>
    {
        public void Configure(EntityTypeBuilder<tSupplier> builder)
        {
           builder.HasKey(s=>s.kSupplierId);
            builder.HasMany(s => s.tProducts)
                .WithOne(s => s.kSupplier)
                .HasForeignKey(s => s.kSupplierId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
