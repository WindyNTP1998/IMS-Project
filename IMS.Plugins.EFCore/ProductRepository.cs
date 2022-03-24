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

        public async Task AddProductAsync(Product product)
        {
            if (_context.Products
                .Any(x => x.ProductName
                .Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
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