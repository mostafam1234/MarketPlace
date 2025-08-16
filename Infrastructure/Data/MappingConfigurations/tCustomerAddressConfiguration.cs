namespace Infrastructure.Data.MappingConfigurations
{
    public class tCustomerAddressConfiguration : IEntityTypeConfiguration<tCustomerAddress>
    {
        public void Configure(EntityTypeBuilder<tCustomerAddress> builder)
        {
            builder.HasKey(c=>c.kCustomerAddressId);
            builder.HasMany(c=>c.tOrders)
                .WithOne(c=>c.kOrderAddress)
                .HasForeignKey(c=>c.kOrderAddressId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(c=>c.kCustomer)
                .WithMany(c=>c.tCustomerAddresses)
                .HasForeignKey(c=>c.kCustomerId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
