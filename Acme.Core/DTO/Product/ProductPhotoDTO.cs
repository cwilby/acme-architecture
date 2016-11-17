namespace Acme.Core.DTO.Product
{
    public class ProductPhotoDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ImageUrl { get; set; }
    }
}