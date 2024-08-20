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
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(m => m.MerchantId);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(m => m.Deliveries).WithOne(d => d.Merchant).HasForeignKey(d => d.MerchantId);
        }
    }
}
