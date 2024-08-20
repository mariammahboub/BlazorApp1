using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Repository.Data.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.StoreId);
            builder.Property(s => s.Type).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Country).IsRequired().HasMaxLength(50);
            builder.Property(s => s.StoreName).IsRequired().HasMaxLength(100);
            builder.HasMany(s => s.CustomerLocations).WithOne().HasForeignKey(scl => scl.StoreId);
        }
    }
}
