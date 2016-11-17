using System;
using System.Collections.Generic;

namespace Acme.Core.DTO.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public DateTime CreatedDate { get; set; }

        public class WithRelations : OrderDTO
        {
            public IEnumerable<PurchaseDTO> Products { get; set; }
        }
    }
}
