using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Repository.Data.Config
{
    public class StoreCustomerLocationConfiguration : IEntityTypeConfiguration<StoreCustomerLocation>
    {
        public void Configure(EntityTypeBuilder<StoreCustomerLocation> builder)
        {
            // Configuring the GoodsDeliveryIds property with conversion and comparison logic
            var goodsDeliveryIdsComparer = new ValueComparer<List<int>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList() ?? new List<int>() // Handle null
            );

            builder.Property(scl => scl.GoodsDeliveryIds)
                   .HasConversion(
                       v => v != null ? string.Join(',', v) : string.Empty,
                       v => string.IsNullOrWhiteSpace(v) ? new List<int>() : v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                   )
                   .Metadata.SetValueComparer(goodsDeliveryIdsComparer);

            // Configuring relationships
            builder.HasOne(scl => scl.Store)
                   .WithMany(s => s.CustomerLocations)
                   .HasForeignKey(scl => scl.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(scl => scl.Customer)
                   .WithMany(c => c.StoreCustomerLocations)
                   .HasForeignKey(scl => scl.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
