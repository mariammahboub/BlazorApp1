using System.ComponentModel.DataAnnotations;

namespace Core.Models
{

    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<string> TelephoneNumbers { get; set; } = new List<string>();
        public ICollection<StoreCustomerLocation> StoreCustomerLocations { get; set; } = new List<StoreCustomerLocation>();
        public List<Delivery> Deliveries { get; set; } = new List<Delivery>();

    }
}
