using Asp.Net_WebApI_Code_Channgle.Database;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Asp.Net_WebApI_Code_Channgle.Services
{
    public class OrderService :IOrderService
    {
        private readonly ChallengeContext Context=null;

        public OrderService(ChallengeContext context)
        {
            Context = context;
        }

        public List<Order> GetOrders()
        {
            try
            {
                var res = Context.Orders.ToList();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Order GetOrdersByProductId(int productId)
        {
            try
            {
                var res = Context.Orders.SingleOrDefault(O => O.ProductId == productId);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PlaceOrder(Order order)
        {
            try
            {
                Context.Orders.Add(order);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
