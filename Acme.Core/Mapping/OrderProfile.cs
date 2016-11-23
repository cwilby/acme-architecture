using Acme.Core.Domain.Order;
using Acme.Core.DTO.Order;
using AutoMapper;

namespace Acme.Core.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<Order, OrderDTO.WithRelations>();

            CreateMap<Purchase, PurchaseDTO>();
            CreateMap<Purchase, PurchaseDTO.WithOrder>();
            CreateMap<Purchase, PurchaseDTO.WithProduct>();
            CreateMap<Purchase, PurchaseDTO.WithRelations>();
        }
    }
}
