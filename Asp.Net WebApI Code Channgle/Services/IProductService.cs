using Asp.Net_WebApI_Code_Channgle.Entitys;

namespace Asp.Net_WebApI_Code_Channgle.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        void AddProduct(Product product);
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
