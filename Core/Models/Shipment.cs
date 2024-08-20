using System.ComponentModel.DataAnnotations;


namespace Core.Models
{

    public class Shipment : BaseEntity
    {
        [Key]
        public int ShipmentId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public List<Container> Containers { get; set; }
    }
}
