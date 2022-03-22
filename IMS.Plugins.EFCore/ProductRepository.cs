using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext _context;
        public ProductRepository(IMSContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            return await this._context
            .Products
            .Where(p => p.ProductName
                .Contains(productName, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
        }
    }


}