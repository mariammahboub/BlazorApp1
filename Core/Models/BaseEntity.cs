namespace Core.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        protected BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
            UpdateDate = CreationDate;
        }
    }
}
