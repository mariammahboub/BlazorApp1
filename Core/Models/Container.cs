using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Container : BaseEntity
    {
        [Key]
        public int ContainerId { get; set; }

        public string ContainerNumber { get; set; }
        public string SealNumber { get; set; }
        public List<Store> Stores { get; set; } = new List<Store>();
        public double Length { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public List<Consignment> Consignments { get; set; } = new List<Consignment>();
        public Shipment ParentShipment { get; set; }
        public int ShipmentId { get; set; }
    }
}
