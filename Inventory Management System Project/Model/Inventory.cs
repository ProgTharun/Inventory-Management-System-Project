using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Model
{
    internal class Inventory
    {
        public int InventoryId { get; set; }
        public string Location { get; set; }
        public List<Product>products { get; set; }
        public List<Supplier> suppliers { get; set; }
        public List<Transaction> transactions { get; set; }

        public override string ToString()
        {
            return $"Inventory Id:{InventoryId}\n" +
                $"Location:{Location}";
        }


    }
}
