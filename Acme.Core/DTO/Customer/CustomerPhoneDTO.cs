using Acme.Core.Domain;

namespace Acme.Core.DTO.Customer
{
    public class CustomerPhoneDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public PhoneTypes PhoneTypeId { get; set; }

        public string Number { get; set; }
    }
}
