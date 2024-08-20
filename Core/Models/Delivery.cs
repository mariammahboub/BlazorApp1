using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Delivery : BaseEntity
    {
        [Key]
        public int DeliveryId { get; set; }
        public int StoreId { get; set; }
        public int? MerchantId { get; set; }
        public int NumberOfCartons { get; set; }
        public int? CustomerId { get; set; }
        public GoodsType GoodsType { get; set; }
        public string Notes { get; set; }
        public double ShipPrice { get; set; }
        public double Volume { get; set; }

        // Ensure there is a public setter
        public GoodsPrice? GoodsPricing { get; set; }

        public Merchant? Merchant { get; set; }
        public Store? Store { get; set; }
        public Customer? Customer { get; set; }
    }
}
