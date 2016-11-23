using Acme.Core.DTO.Product;
using Acme.Core.Infrastructure.Interfaces;
using System;

namespace Acme.Core.Domain.Product
{
    public class ProductPhoto : ICreatedDate
    {
        public ProductPhoto()
        {

        }
        public ProductPhoto(ProductPhotoDTO photo) : this()
        {
            CreatedDate = DateTime.UtcNow;
            ProductId = photo.ProductId;
            SetFields(photo);
        }

        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Product Product { get; set; }

        public void SetFields(ProductPhotoDTO photo)
        {
            ImageUrl = photo.ImageUrl;
        }
    }
}
