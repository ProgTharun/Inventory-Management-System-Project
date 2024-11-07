using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Model
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ? ProductId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int ? InventoryId { get; set; }


        public override string ToString()
        {
            return $"Transaction ID: {TransactionId}\n" +
                $"ProductId: {ProductId}\n" +
                $"Type: {Type}\n" +
           $"Quantity: {Quantity}\n" +
           $"DateTime:{Date}" +
           $"Inventory Id:{InventoryId}";
        }


    }
}
