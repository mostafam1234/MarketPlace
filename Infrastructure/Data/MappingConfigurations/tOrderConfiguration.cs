namespace Infrastructure.Data.MappingConfigurations
{
    public class tOrderConfiguration : IEntityTypeConfiguration<tOrder>
    {
        public void Configure(EntityTypeBuilder<tOrder> builder)
        {
            builder.HasKey(o => o.kOrderId);
            builder.HasMany(o => o.tOrderPositions)
                .WithOne(o => o.kOrder)
                .HasForeignKey(o => o.kOrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(o=>o.tShippingPackages)
                .WithOne(o=>o.kOrder)
                .HasForeignKey(o=>o.kOrderId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(o=>o.kCustomer)
                .WithMany(o=>o.tOrders)
                .HasForeignKey(o=>o.kCustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.kOrderAddress)
                .WithMany(o => o.tOrders)
                .HasForeignKey(o => o.kOrderAddressId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(o => o.kPaymentMethod)
                .WithMany(o => o.tOrders)
                .HasForeignKey(o => o.kPaymentMethodId)
                .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
