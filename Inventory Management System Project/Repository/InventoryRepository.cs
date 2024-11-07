using Inventory_Management_System_Project.Context;
using Inventory_Management_System_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Repository
{
    internal class InventoryRepository
    {
        private InventoryContext _inventoryContext;

        public InventoryRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public List<Inventory> GetAll()
        {
            return _inventoryContext.Inventories.ToList();
        }

        public Inventory GetId(int id)
        {
            var inventory = _inventoryContext.Inventories.FirstOrDefault(x => x.InventoryId == id);
            if (inventory != null)
                return inventory;
            return null;
        }

        public void Add(Inventory inventory)
        {
            _inventoryContext.Inventories.Add(inventory);
            _inventoryContext.SaveChanges();
        }
        public List<Inventory> ShowInventory()
        {
            var list = _inventoryContext.Inventories
         // Include Inventory for each Product (if necessary)
        .Include(inventory => inventory.products)  // Load related Products for each Inventory
            .Include(product => product.suppliers) // Load Supplier for each Product
        .Include(inventory => inventory.transactions)  // Load related Transactions for each Inventory
        .ToList(); // Execute the query and get the result as a List

            return list;

        }

    }
}
