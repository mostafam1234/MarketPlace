namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductVariantConfiguration : IEntityTypeConfiguration<tProductVariant>
    {
        public void Configure(EntityTypeBuilder<tProductVariant> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.HasMany(p => p.tOrderPositions)
                .WithOne(p => p.kVariant)
                .HasForeignKey(p => p.kVariantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.tProductStocks)
               .WithOne(p => p.kProductVariant)
               .HasForeignKey(p => p.kProductVariantId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.tVariant_Attributes)
               .WithOne(p => p.variant)
               .HasForeignKey(p => p.variant_id)
               .OnDelete(DeleteBehavior.Restrict);   
            builder.HasOne(p=>p.Product)
                .WithMany()
                .HasForeignKey(p=>p.Product_Id)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
