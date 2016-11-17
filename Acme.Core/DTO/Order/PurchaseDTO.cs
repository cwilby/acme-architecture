using Acme.Core.DTO.Product;

namespace Acme.Core.DTO.Order
{
    public class PurchaseDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public class WithRelations : PurchaseDTO
        {
            public ProductDTO Product { get; set; }
            public OrderDTO Order { get; set; }
        }

        public class WithProduct : PurchaseDTO
        {
            public ProductDTO Product { get; set; }
        }
        public class WithOrder : PurchaseDTO
        {
            public OrderDTO Order { get; set; }
        }
    }
}