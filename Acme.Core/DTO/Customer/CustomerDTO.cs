using System.Collections.Generic;

namespace Acme.Core.DTO.Customer
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public class WithRelations : CustomerDTO
        {
            public IEnumerable<CustomerEmailDTO> Emails { get; set; }
            public IEnumerable<CustomerPhoneDTO> Phones { get; set; }
        }
    }
}
