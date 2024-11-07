using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Model
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string PrdouctName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId}\n"+
                $" Product Name: {PrdouctName}\n"+
                $" Product Description: {ProductDescription}\n"+
            $"Product Price: {ProductPrice}\n"+
           $" Product Quantity: {ProductQuantity}\n"+
            $"Inventory Id:{InventoryId}";
        }



    }


}

