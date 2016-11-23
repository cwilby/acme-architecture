using Acme.Core.DTO.Order;

namespace Acme.Core.Domain.Order
{
    public class Purchase
    {
        public Purchase()
        {

        }
        public Purchase(PurchaseDTO purchase) : this()
        {
            OrderId = purchase.OrderId;
            ProductId = purchase.ProductId;
            SetFields(purchase);
        }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product.Product Product { get; set; }

        public void SetFields(PurchaseDTO purchase)
        {
            Quantity = purchase.Quantity;
        }
    }
}