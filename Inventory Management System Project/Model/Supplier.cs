using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Model
{
    internal class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public double Contact {  get; set; }
        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int ? InventoryId { get; set; }

        public override string ToString()
        {
            return $"Supplier ID: {SupplierId}\n" +
                $"Supplier Name: {SupplierName}\n" +
                $"Supplier Contact: {Contact}\n"+
                 $"Inventory Id:{InventoryId}";
        }


    }
}
