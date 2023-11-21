using Asp.Net_WebApI_Code_Channgle.Entitys;

namespace Asp.Net_WebApI_Code_Channgle.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        List<Order> GetOrders();
        Order GetOrdersByProductId(int productId);
    }
}
