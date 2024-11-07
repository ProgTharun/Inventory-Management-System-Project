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
    internal class ProductRepository
    {
        InventoryContext _inventoryContext;
        public ProductRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public void AddNewProduct(Product product)
        {
            _inventoryContext.Products.Add(product);
            _inventoryContext.SaveChanges();
        }
        public void UpdaterProductDetails(Product product)
        {
            var existingProduct = _inventoryContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
                throw new ProductNotFoundException("Product Not Found");
                

            _inventoryContext.Entry(product).State = EntityState.Modified;
            _inventoryContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {

            var products = _inventoryContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (product == null)
                
                return;

            _inventoryContext.Products.Remove(product);
            _inventoryContext.SaveChanges();
        }
        public List<Product> GetAllProducts()
        {
           var Products= _inventoryContext.Products.ToList();
            return Products;

        }

        public Product ViewProductDetails(int Id)
        {
            var product = _inventoryContext.Products.FirstOrDefault(p => p.ProductId == Id);
            if (product == null)
            {
               
                return null;
            }
            return product;
        }
    }
   
}

