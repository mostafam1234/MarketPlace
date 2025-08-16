namespace Infrastructure.Data.MappingConfigurations
{
    public class tCustomerConfiguration : IEntityTypeConfiguration<tCustomer>
    {
        public void Configure(EntityTypeBuilder<tCustomer> builder)
        {
            builder.HasKey(c=>c.kCustomerId);
            builder.HasOne(c => c.kCustomerGroup)
                .WithMany(g => g.tCustomers)
                .HasForeignKey(c => c.kCustomerGroupId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.tCustomerAddresses)
             .WithOne(a => a.kCustomer)
              .HasForeignKey(c=>c.kCustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.tOrders)
               .WithOne(o => o.kCustomer)
                .HasForeignKey(c=>c.kCustomerId)
                
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
