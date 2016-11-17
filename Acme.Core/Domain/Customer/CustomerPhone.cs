namespace Acme.Core.Domain.Customer
{
    public class CustomerPhone
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public PhoneTypes PhoneTypeId { get; set; }

        public string Number { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
