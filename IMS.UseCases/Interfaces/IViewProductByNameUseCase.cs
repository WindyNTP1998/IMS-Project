using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IViewProductByNameUseCase
    {
        Task<List<Product>> ExecuteAsync(string productName);
    }
}