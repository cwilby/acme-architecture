namespace Acme.Core.Domain.Customer
{
    public class CustomerEmail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public bool IsPrimary { get; set; }
        public string Address { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
