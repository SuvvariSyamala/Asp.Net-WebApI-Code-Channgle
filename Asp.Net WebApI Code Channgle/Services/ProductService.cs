using Asp.Net_WebApI_Code_Channgle.Database;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApI_Code_Channgle.Services
{
    public class ProductService :IProductService
    {
        private readonly ChallengeContext Context;

        public ProductService(ChallengeContext context)
        {
            Context = context;
        }

        public void AddProduct(Product product)
        {
            try
            {
                Context.Products.Add(product);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                
                Product product = Context.Products.FirstOrDefault(p => p.ProductId == productId); 
                Context.Products.Remove(product);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetAllProducts()
        {
            return Context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            try
            {
                Product product = Context.Products.SingleOrDefault(p => p.ProductId == productId);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                if (product != null)
                {

                    Context.Products.Update(product);
                    Context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
