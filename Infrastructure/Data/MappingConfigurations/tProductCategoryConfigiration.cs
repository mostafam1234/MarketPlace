using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tProductCategoryConfigiration : IEntityTypeConfiguration<tProductCategory>
    {
        public void Configure(EntityTypeBuilder<tProductCategory> builder)
        {
            builder.HasKey(p=>p.kProductCategoryId);
            builder.HasOne(pc => pc.kUpperCategory) 
          .WithMany(pc => pc.InversekUpperCategory) 
          .HasForeignKey(pc => pc.kUpperCategoryId) 
          .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(pc => pc.tProducts) 
                   .WithOne(pc=>pc.Category) 
                   .HasForeignKey(p => p.CategoryId) 
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
