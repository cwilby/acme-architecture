namespace Acme.Core.Domain.Product
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ImageUrl { get; set; }

        public virtual Product Product { get; set; }
    }
}
