namespace Acme.Core.Domain.Order
{
    public class Purchase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product.Product Product { get; set; }
    }
}