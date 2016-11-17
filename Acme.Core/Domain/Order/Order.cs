using System;
using System.Collections.Generic;

namespace Acme.Core.Domain.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Purchase> Products { get; set; } 
    }
}
