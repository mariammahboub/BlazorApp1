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
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.ShipmentId);
            builder.Property(s => s.Origin).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Destination).IsRequired().HasMaxLength(100);
            builder.HasMany(s => s.Containers).WithOne(c => c.ParentShipment).HasForeignKey(c => c.ShipmentId);
        }
    }
}
