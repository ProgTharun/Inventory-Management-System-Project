using Inventory_Management_System_Project.Context;
using Inventory_Management_System_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Inventory_Management_System_Project.Repository
{
    internal class TransactionRepository
    {
        InventoryContext _inventoryContext;
        public TransactionRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public List<Model.Transaction> GetAll()
        {
            return _inventoryContext.Transactions.ToList();
        }

        public List<Model.Transaction> GetByProductID(int productID)
        {
          
            return _inventoryContext.Transactions.Where(id => id.ProductId == productID).ToList();
            if (productID == null)
                throw TransactionNotCommitedException("Transaction.Product Id Not Found");
        }

        private Exception TransactionNotCommitedException(string v)
        {
            throw new NotImplementedException();
        }

        public void Add(Model.Transaction transaction)
        {
            _inventoryContext.Transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }



    }
}
