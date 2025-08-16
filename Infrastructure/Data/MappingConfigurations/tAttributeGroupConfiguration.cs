using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tAttributeGroupConfiguration : IEntityTypeConfiguration<tAttributeGroup>
    {
        public void Configure(EntityTypeBuilder<tAttributeGroup> builder)
        {
            builder.HasKey(a=>a.kAttributeGroupId);
        }
    }
}
