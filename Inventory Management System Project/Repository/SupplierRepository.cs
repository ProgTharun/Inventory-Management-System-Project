using Inventory_Management_System_Project.Context;
using Inventory_Management_System_Project.Exceptions;
using Inventory_Management_System_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Repository
{
    internal class SupplierRepository
    {
        InventoryContext _inventoryContext;
        public SupplierRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public void AddNewSupplier(Supplier suppliers)
        {
            _inventoryContext.Suppliers.Add(suppliers);
            _inventoryContext.SaveChanges();
        }
        public void UpdaterSupplierDetails(Supplier suppliers)
        {
            var existingSuppliers = _inventoryContext.Suppliers.FirstOrDefault(p => p.SupplierId == suppliers.SupplierId);
            if (existingSuppliers == null)
                 throw new SupplierNotFoundException("Supplier Not Found");
               

            _inventoryContext.Entry(suppliers).State = EntityState.Modified;
            _inventoryContext.SaveChanges();
        }

        public void DeleteSupplier(Supplier supplier)
        {

            var suppliers = _inventoryContext.Suppliers.FirstOrDefault(p => p.SupplierId ==supplier.SupplierId);
            if (suppliers == null)
                
                return;

            _inventoryContext.Suppliers.Remove(supplier);
            _inventoryContext.SaveChanges();
        }
        public List<Supplier> GetAllSuppliers()
        {
            var Suppliers = _inventoryContext.Suppliers.ToList();
            return Suppliers;

        }

        public Supplier ViewSupplierDetails(int Id)
        {
            var supplier = _inventoryContext.Suppliers.FirstOrDefault(p => p.SupplierId == Id);
            if (supplier == null)
            {
              
               
            }
            return supplier;
        }
    }
}

