using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tLogLevelConfiguration : IEntityTypeConfiguration<tLogLevel>
    {
        public void Configure(EntityTypeBuilder<tLogLevel> builder)
        {
            builder.HasKey(s => s.kLogLevelId);

        }
    }
}
