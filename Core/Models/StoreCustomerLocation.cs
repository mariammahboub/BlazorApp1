using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class StoreCustomerLocation : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public List<int>? GoodsDeliveryIds { get; set; } // Ensure this is nullable
        public int NumberOfCartons { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
        public Customer? Customer { get; set; }
    }
}
