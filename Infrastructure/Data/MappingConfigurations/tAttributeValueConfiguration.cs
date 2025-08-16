namespace Infrastructure.Data.MappingConfigurations
{
    public class TAttributeValueConfiguration : IEntityTypeConfiguration<tAttributeValue>
    {
        public void Configure(EntityTypeBuilder<tAttributeValue> builder)
        {
            builder.HasKey(at => at.kAttributeValueId);
            builder.HasOne(e => e.kAttribue) 
               .WithMany()
               .HasForeignKey(e => e.kAttribueId)
               .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(e => e.tVariant_Attributes) 
                .WithOne() 
                .HasForeignKey(e=>e.AttributeValueId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
