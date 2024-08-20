using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Repository.Data.Config
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d => d.DeliveryId);
            builder.Property(d => d.Notes).HasMaxLength(500);
            builder.Property(d => d.ShipPrice).HasColumnType("decimal(18,2)");
            builder.Property(d => d.Volume).HasColumnType("decimal(18,2)");

            // Configure GoodsPrice as an owned type
            builder.OwnsOne(d => d.GoodsPricing, g =>
            {
                g.Property(gp => gp.DefaultPricePerCubicMeter).HasColumnName("DefaultPricePerCubicMeter");
                g.Property(gp => gp.TotalPrice).HasColumnName("TotalPrice");
                g.Property(gp => gp.Type).HasColumnName("GoodsType");
            });

            builder.HasOne(d => d.Merchant)
                   .WithMany(m => m.Deliveries)
                   .HasForeignKey(d => d.MerchantId);

            builder.HasOne(d => d.Store)
                   .WithMany(s => s.Deliveries)
                   .HasForeignKey(d => d.StoreId);

            builder.HasOne(d => d.Customer)
                   .WithMany(c => c.Deliveries)
                   .HasForeignKey(d => d.CustomerId);
        }
    }
}
