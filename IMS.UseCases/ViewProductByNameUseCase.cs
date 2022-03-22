using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases
{
    public class ViewProductByNameUseCase : IViewProductByNameUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductByNameUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> ExecuteAsync(string productName = "")
        {
            return await _productRepository.GetProductsByNameAsync(productName);
        }

    }
}