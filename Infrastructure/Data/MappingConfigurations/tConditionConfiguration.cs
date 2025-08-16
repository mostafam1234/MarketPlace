namespace Infrastructure.Data.MappingConfigurations
{
    public class tConditionConfiguration : IEntityTypeConfiguration<tCondition>
    {
        public void Configure(EntityTypeBuilder<tCondition> builder)
        {
            builder.HasKey(c=>c.kConditionId);
            builder.HasMany(c => c.tProducts)
                .WithOne()
                .HasForeignKey(p => p.kConditionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
