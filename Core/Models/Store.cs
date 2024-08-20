using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Models
{
    public class Store : BaseEntity
    {
        [Key]
        public int StoreId { get; set; }
        [Required]  // Ensure this field is required

        public string Type { get; set; }
        [Required]  // Ensure this field is required

        public string Country { get; set; }
        [Required]  // Ensure this field is required

        public string StoreName { get; set; }
        [JsonIgnore]
        public List<StoreCustomerLocation> CustomerLocations { get; set; } = new List<StoreCustomerLocation>();
        public List<Delivery> Deliveries { get; set; } = new List<Delivery>();

    }
}
