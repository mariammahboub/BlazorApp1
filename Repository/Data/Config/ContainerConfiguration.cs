using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Data.Config
{
    public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.HasKey(c => c.ContainerId);
            builder.Property(c => c.ContainerNumber).IsRequired().HasMaxLength(50);
            builder.Property(c => c.SealNumber).IsRequired().HasMaxLength(50);

            builder.HasIndex(c => c.SealNumber).IsUnique();

            // Configure one-to-many relationship with Store entity
            builder.HasMany(c => c.Stores)
                   .WithOne()
                   .HasForeignKey("ContainerId");

            // Configure one-to-many relationship with Consignment entity
            builder.HasMany(c => c.Consignments)
                   .WithOne(c => c.Container) 
                   .HasForeignKey(c => c.ContainerId);
            // Configure one-to-many relationship with Shipment entity
            builder.HasOne(c => c.ParentShipment)
                   .WithMany(s => s.Containers) 
                   .HasForeignKey(c => c.ShipmentId);
        }
    }
}
