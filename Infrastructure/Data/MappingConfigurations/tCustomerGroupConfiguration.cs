namespace Infrastructure.Data.MappingConfigurations
{
    public class tCustomerGroupConfiguration : IEntityTypeConfiguration<tCustomerGroup>
    {
        public void Configure(EntityTypeBuilder<tCustomerGroup> builder)
        {
            builder.HasKey(c=>c.kCustomerGroupId);
            builder.HasMany(c => c.tCustomers)
                .WithOne(c => c.kCustomerGroup)
                .HasForeignKey(c => c.kCustomerGroupId)
                .OnDelete(DeleteBehavior.SetNull); 
                

        }
    }
}
