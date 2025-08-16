namespace Infrastructure.Data.MappingConfigurations
{
    public class tVariant_AttributeConfiguration : IEntityTypeConfiguration<tVariant_Attribute>
    {
        public void Configure(EntityTypeBuilder<tVariant_Attribute> builder)
        {
            builder.HasKey(v=>v.id);
            builder.HasOne(v => v.AttributeValue)
                .WithMany()
                .HasForeignKey(v=>v.AttributeValueId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(v=>v.variant)
                .WithMany()
                .HasForeignKey(v=>v.variant_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
