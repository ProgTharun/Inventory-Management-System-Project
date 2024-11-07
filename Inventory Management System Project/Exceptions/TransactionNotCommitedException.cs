using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Exceptions
{
    internal class TransactionNotCommitedException:Exception
    {
        public TransactionNotCommitedException(string message):base(message) { }
    }
}
