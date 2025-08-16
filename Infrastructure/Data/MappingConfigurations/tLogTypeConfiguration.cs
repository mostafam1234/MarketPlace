using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tLogTypeConfiguration : IEntityTypeConfiguration<tLogType>
    {
        public void Configure(EntityTypeBuilder<tLogType> builder)
        {
            builder.HasKey(s=>s.kLogTypeId);
        }
    }
}
