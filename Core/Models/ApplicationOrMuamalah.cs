using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class ApplicationOrMuamalah : BaseEntity
    {
        [Key]
        public int ApplicationId { get; set; }
        public int CustomerId { get; set; }
        public ApplicationType Type { get; set; }
        public double Cost { get; set; }
    }
}
