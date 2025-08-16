using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tLogEntityConfiguration : IEntityTypeConfiguration<tLogEntry>
    {
        public void Configure(EntityTypeBuilder<tLogEntry> builder)
        {
            builder.HasKey(le => new { le.kLogLevelId, le.kLogTypeId });
            builder.HasOne(le => le.kLogLevel)
          .WithOne() 
          .HasForeignKey<tLogEntry>(le => le.kLogLevelId)
          .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(le => le.kLogType)
             .WithOne() 
             .HasForeignKey<tLogEntry>(le => le.kLogTypeId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
