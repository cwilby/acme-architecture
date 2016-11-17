namespace Acme.Core.DTO.Customer
{
    public class CustomerEmailDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public bool IsPrimary { get; set; }
        public string Address { get; set; }
    }
}
