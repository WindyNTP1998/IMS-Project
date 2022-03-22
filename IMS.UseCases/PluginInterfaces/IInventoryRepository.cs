using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoriesByName(string name);
        Task UpdateInventoryAsync(Inventory inventory);
        Task<Inventory?> GetInventoryByIdAsync(int inventoryId);
    }
}
