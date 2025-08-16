namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductDescriptionConfiguration : IEntityTypeConfiguration<tProductDescription>
    {
        public void Configure(EntityTypeBuilder<tProductDescription> builder)
        {
            builder.HasKey(p=>p.kProductDescriptionId);
            builder.HasOne(p => p.kLanguage)
                .WithMany()
                .HasForeignKey(p => p.kLanguageId)
                .OnDelete(DeleteBehavior.SetNull);


            // not completed
        }
    }
}
