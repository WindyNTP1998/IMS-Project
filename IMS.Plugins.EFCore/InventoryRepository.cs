using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{


    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext _db;

        public InventoryRepository(IMSContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await _db.Inventories
            .Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                     string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            if (_db.Inventories.Any(x => x.InventoryName
                 .Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return;



            _db.Inventories.Add(inventory);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_db.Inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                 x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) return;

            var invs = await _db.Inventories.FindAsync(inventory.InventoryId);
            if (invs != null)
            {
                invs.InventoryName = inventory.InventoryName;
                invs.Price = inventory.Price;
                invs.Quantity = inventory.Quantity;
            }
            _db.SaveChanges();
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        {
            return await _db.Inventories.FindAsync(inventoryId);
        }
    }
}