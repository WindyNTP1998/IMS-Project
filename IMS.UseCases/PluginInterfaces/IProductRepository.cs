using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByNameAsync(string productName);
    }
}