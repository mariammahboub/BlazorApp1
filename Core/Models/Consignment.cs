namespace Core.Models
{
    public class Consignment:BaseEntity
    {
        public int ConsignmentId { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public int ContainerId { get; set; }
        public Container Container { get; set; }
    }
}
