using Asp.Net_WebApI_Code_Channgle.DTO;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using AutoMapper;

namespace Asp.Net_WebApI_Code_Channgle.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
