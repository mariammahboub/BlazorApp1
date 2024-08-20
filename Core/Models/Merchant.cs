
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Merchant : BaseEntity
    {
        [Key]
        public int MerchantId { get; set; }
        public string Name { get; set; }

        public ICollection<Delivery>? Deliveries { get; set; }
    }
}
