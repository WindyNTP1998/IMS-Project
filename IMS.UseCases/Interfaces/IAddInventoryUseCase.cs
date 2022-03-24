using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}