namespace Infrastructure.Data.MappingConfigurations
{
    public class tSalesChannelProductMappingConfiguration : IEntityTypeConfiguration<tSalesChannelProductMapping>
    {
        public void Configure(EntityTypeBuilder<tSalesChannelProductMapping> builder)
        {
            builder.HasKey(s=>s.kSalesChannelProductMappingId);
            builder.HasMany(s => s.tProducts)
                .WithOne(s=>s.kSalesChannelProductMapping)
                //.HasForeignKey(s => s.kResponsiblePersonGPSR)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
