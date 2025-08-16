namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductConfiguration : IEntityTypeConfiguration<tProduct>
    {
        public void Configure(EntityTypeBuilder<tProduct> builder)
        {
            builder.HasKey(p => p.kProductId);

            builder.HasOne(p=>p.Category)
                .WithMany(c=>c.tProducts)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.kCondition)
                .WithMany()
                .HasForeignKey(p => p.kConditionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.kManufacturer)
                .WithMany()
                .HasForeignKey(p => p.kManufacturerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.kResponsiblePersonGPSR)
                .WithMany()
                .HasForeignKey(p => p.kResponsiblePersonGPSRId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.kSalesChannelProductMapping)
                .WithMany()
                .HasForeignKey(p => p.kSalesChannelProductMappingId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.kSupplier)
                .WithMany()
                .HasForeignKey(p => p.kSupplierId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.kVatTypeNavigation)
                .WithMany()
                .HasForeignKey(p => p.kVatTypeId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(p => p.ProductMarketplaces)
               .WithOne(p => p.Product)
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.tProductVariants)
                .WithOne(v => v.Product)
                .HasForeignKey(v=>v.Product_Id)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.AttributeMappings)
         .WithOne(v => v.tProduct)
         .HasForeignKey(v=>v.kAttributeValueId)
         .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
