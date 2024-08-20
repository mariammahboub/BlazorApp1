namespace Core.Models
{
    public class GoodsPrice : BaseEntity
    {
        public int Id { get; set; }
        public GoodsType Type { get; set; }
        public double DefaultPricePerCubicMeter { get; set; }
        public double TotalPrice { get; set; }

        // Parameterless constructor required by EF Core
        public GoodsPrice() { }

        public GoodsPrice(GoodsType type, double defaultPricePerCubicMeter)
        {
            Type = type;
            DefaultPricePerCubicMeter = defaultPricePerCubicMeter;
        }

        public void CalculateTotalPrice(double volume)
        {
            TotalPrice = DefaultPricePerCubicMeter * volume;
        }
    }
}
