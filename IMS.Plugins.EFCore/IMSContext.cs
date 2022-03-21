using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                 new Inventory { InventoryId = 1, InventoryName = "Gas Engine", Price = 1000, Quantity = 1 },
                 new Inventory { InventoryId = 2, InventoryName = "Body", Price = 400, Quantity = 1 },
                 new Inventory { InventoryId = 3, InventoryName = "Wheel", Quantity = 4, Price = 100 },
                 new Inventory { InventoryId = 4, InventoryName = "Seat", Price = 50, Quantity = 5 },
                 new Inventory { InventoryId = 5, InventoryName = "Electric Engine", Price = 8000, Quantity = 2 },
                 new Inventory { InventoryId = 6, InventoryName = "Battery", Price = 400, Quantity = 5 }
             );
        }
    }
}
