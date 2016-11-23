using Acme.Core.Domain.Product;
using Acme.Core.DTO.Product;
using AutoMapper;

namespace Acme.Core.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDTO.WithRelations>();
            CreateMap<ProductPhoto, ProductPhotoDTO>();
        }
    }
}
