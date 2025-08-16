using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tLanguageConfiguration : IEntityTypeConfiguration<tLanguage>
    {
        public void Configure(EntityTypeBuilder<tLanguage> builder)
        {
            builder.HasKey(l=>l.kLanguageId);
            builder.HasMany(l=>l.tProductDescriptions)
                .WithOne(l=>l.kLanguage)
                .HasForeignKey(l=>l.kLanguageId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
