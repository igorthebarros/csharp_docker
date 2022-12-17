namespace Domain.Data.Models
{
    public class BaseClass
    {
        public BaseClass()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public DateTime CreatedAt { get; }
        public bool IsActive { get; set; }
    }
}
