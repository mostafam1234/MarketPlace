using CoreSystem.DAL.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MappingConfigurations
{
    public class tAttributeConfiguration : IEntityTypeConfiguration<tAttribute>
    {
        public void Configure(EntityTypeBuilder<tAttribute> builder)
        {
            builder.HasKey(a=>a.kAttributeId);
            builder.HasMany(a => a.tAttributeValues)
                .WithOne()
                .HasForeignKey(a=>a.kAttribueId)
                .OnDelete(DeleteBehavior.Restrict);
        
        }
    }
}
