using Inventory_Management_System_Project.Exceptions;
using Inventory_Management_System_Project.Model;
using Inventory_Management_System_Project.Repository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_Project.Presentation
{
    internal class Menu
    {
        public static void MainMenue()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Inventory Management System");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Supplier Management");
                Console.WriteLine("3. Transaction Management");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ProductManagement();
                        break;
                    case 2:
                        SupplierManagement();
                        break;
                    case 3:
                        TransactionManagement();
                        break;
                    case 4:
                        GenerateReport();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }
        private static void ProductManagement()
        {
            ProductRepository productRepo = new ProductRepository();

            bool continueProductMenu = true;
            while (continueProductMenu)
            {
                Console.WriteLine("\nProduct Management Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Product's Details");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Go Back Main Menu");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct(productRepo);
                        break;
                    case 2:
                        UpdateProduct(productRepo);
                        break;
                    case 3:
                        DeleteProduct(productRepo);
                        break;
                    case 4:
                        GetProductById(productRepo);
                        break;
                    case 5:
                        ViewAllProducts(productRepo);
                        break;
                    case 6:
                        continueProductMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        private static void ViewAllProducts(ProductRepository productRepository)
        {
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine("===============================");
            }
        }

        private static (bool, Product) GetProductById(ProductRepository productRepository)
        {
            Console.WriteLine("Enter Product Id to Search:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                var product = productRepository.ViewProductDetails(id);
                Console.WriteLine(product);
                return (true, product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (false, null);
            }

        }

        private static void DeleteProduct(ProductRepository productRepository)
        {
            var (productExist, product) = GetProductById(productRepository);
            if (!productExist)
                return;
            productRepository.DeleteProduct(product);
            Console.WriteLine("Product Deleted Successfully :) ");

        }

        private static void AddProduct(ProductRepository productRepository)
        {
            Console.WriteLine("Enter Name of the Product:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Quantity of Product:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price of Product:");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Inventory ID:");
            int id = int.Parse(Console.ReadLine());

            var product = new Product() { PrdouctName = name, ProductDescription = description, ProductQuantity = quantity, ProductPrice = price, InventoryId = id };
            productRepository.AddNewProduct(product);
            Console.WriteLine("Product Added Successfully :) ");
        }

        static void UpdateProduct(ProductRepository productRepository)
        {
            try
            {
                var (productExist, product) = GetProductById(productRepository);
                if (!productExist)
                    return;
                Console.WriteLine("Enter New Name of the Product:");
                product.PrdouctName = Console.ReadLine();
                Console.WriteLine("Enter New Product Description:");
                product.ProductDescription = Console.ReadLine();
                Console.WriteLine("Enter New Quantity of Product:");
                product.ProductQuantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter New Price of Product:");
                product.ProductPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter New Inventory ID:");
                product.InventoryId = int.Parse(Console.ReadLine());

                productRepository.UpdaterProductDetails(product);
                Console.WriteLine("Product Updated Successfully :) ");
            }
            catch(ProductNotFoundException ex)
            {

            Console.WriteLine(ex.Message);
            }
        }
        /*********************** Suppliers Menu********************************************/
        private static void SupplierManagement()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            bool continueSupplierMenu = true;
            while (continueSupplierMenu)
            {
                Console.WriteLine("Suppliers Management:");
                Console.WriteLine("1. Add Supplier");
                Console.WriteLine("2. Update Supplier");
                Console.WriteLine("3. Delete Supplier");
                Console.WriteLine("4. View Supplier's Details");
                Console.WriteLine("5. View All Suppliers");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddSupplier(supplierRepository);
                        break;
                    case 2:
                        UpdateSupplier(supplierRepository);
                        break;
                    case 3:
                        DeleteSupplier(supplierRepository);
                        break;
                    case 4:
                        GetSupplierById(supplierRepository);
                        break;
                    case 5:
                        DisplayAllSuppliers(supplierRepository);
                        break;
                    case 6:
                        continueSupplierMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }


            }
        }
        private static void DisplayAllSuppliers(SupplierRepository supplierRepository)
        {
            var suppliers = supplierRepository.GetAllSuppliers();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine(supplier);
                Console.WriteLine("===============================");
            }
        }

        private static (bool, Supplier) GetSupplierById(SupplierRepository supplierRepository)
        {
            
            
                Console.WriteLine("Enter Supplier Id to Search:");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    var supplier = supplierRepository.ViewSupplierDetails(id);
                    Console.WriteLine(supplier);
                    return (true, supplier);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return (false, null);
                }
            
        }

        private static void AddSupplier(SupplierRepository supplierRepository)
        {
            Console.WriteLine("Enter Supplier Name to Add:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Contact Info of Supplier");
            double contactInfo = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Inventory Id of Supplier");
            int id = int.Parse(Console.ReadLine());

            var supplier = new Supplier() { SupplierName = name, Contact = contactInfo, InventoryId = id };
            supplierRepository.AddNewSupplier(supplier);
            Console.WriteLine("Supplier Added Successfully :) ");
        }

        private static void DeleteSupplier(SupplierRepository supplierRepository)
        {
            var (supplierExist, supplier) = GetSupplierById(supplierRepository);
            if (!supplierExist)
                return;
            supplierRepository.DeleteSupplier(supplier);
            Console.WriteLine("Supplier Deleted Successfully :)");
        }

        static void UpdateSupplier(SupplierRepository supplierRepository)
        {
            try
            {
                var (supplierExist, supplier) = GetSupplierById(supplierRepository);
                if (!supplierExist)
                    return;
                Console.WriteLine("Enter New Supplier Name:");
                supplier.SupplierName = Console.ReadLine();
                Console.WriteLine("Enter New Supplier Contact Info:");
                supplier.Contact = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter New Inventory Id of Supplier:");
                supplier.InventoryId = int.Parse(Console.ReadLine());

                supplierRepository.UpdaterSupplierDetails(supplier);
                Console.WriteLine("Supplier Updated Successfully :) ");
            }
            catch(SupplierNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        /*%%%%%%%%%%%%%%%%%%   Transaction Menu  %%%%%%%%%%%%%%%%%%%%%%%%%%%*/

        private static void TransactionManagement()
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            InventoryRepository inventoryRepository = new InventoryRepository();
            ProductRepository productRepository = new ProductRepository();

            bool continueTransactionMenu = true;
            while (continueTransactionMenu)
            {
                Console.WriteLine("Stock Management:");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. Remove Stock");
                Console.WriteLine("3. View Transaction History");
                Console.WriteLine("4. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStock(productRepository, transactionRepository, inventoryRepository);
                        break;
                    case 2:
                        RemoveStock(productRepository, transactionRepository, inventoryRepository);
                        break;
                    case 3:
                        DisplayAllTransactions(transactionRepository);
                        break;
                    case 4:
                        continueTransactionMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;


                }
            }
            static void DisplayAllTransactions(TransactionRepository transactionRepository)
            {
                var transaction = transactionRepository.GetAll();
                foreach (var trans in transaction)
                {
                    Console.WriteLine(trans);

                }
            }

            static void AddStock(ProductRepository productRepository, TransactionRepository transactionRepository, InventoryRepository inventoryRepository)
            {
                Console.WriteLine("Enter Product ID to Add Stock:");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    var productId = productRepository.ViewProductDetails(id);
                    if (productId == null)
                    {
                        Console.WriteLine("No Product Found with this ID");
                        return;
                    }
                    Console.WriteLine("Enter Inventory Id of Product");
                    int inventoryId = int.Parse(Console.ReadLine());
                    var inventory = inventoryRepository.GetId(inventoryId);
                    if (inventory == null)
                    {
                        Console.WriteLine("No Inventory Exists");
                        return;
                    }

                    Console.WriteLine("Enter Quantity to Add:");
                    int quantity = int.Parse(Console.ReadLine());
                    productId.ProductQuantity += quantity;

                    var transaction = new Transaction() { ProductId = id, Type = "Add", Quantity = quantity, Date = DateTime.Now, InventoryId = inventoryId };

                    productRepository.UpdaterProductDetails(productId);
                    transactionRepository.Add(transaction);
                    Console.WriteLine("Stock Added Successfully :) ");
                }
                catch (TransactionNotCommitedException ex)
                {
                   Console.WriteLine(ex.Message);
                }
            }

            static void RemoveStock(ProductRepository productRepository, TransactionRepository transactionRepository, InventoryRepository inventoryRepository)
            {
                Console.WriteLine("Enter Product ID to Remove Stock:");
                int id = int.Parse(Console.ReadLine());
                var productId = productRepository.ViewProductDetails(id);
                if (productId == null)
                {
                    Console.WriteLine("No Product Found with this ID");
                    return;
                }
                Console.WriteLine("Enter Inventory Id of Product");
                int inventoryId = int.Parse(Console.ReadLine());
                var inventory = inventoryRepository.GetId(inventoryId);
                if (inventory == null)
                {
                    Console.WriteLine("No Inventory Exists");
                    return;
                }

                Console.WriteLine("Enter Quantity to Remove:");
                int quantity = int.Parse(Console.ReadLine());
                productId.ProductQuantity -= quantity;

                var transaction = new Transaction() { ProductId = id, Type = "Remove", Quantity = quantity, Date = DateTime.Now, InventoryId = inventoryId };

                productRepository.UpdaterProductDetails(productId);
                transactionRepository.Add(transaction);
                Console.WriteLine("Stock Removed Successfully :) ");
            }

        }
        /***************** Generate Report  ************************/

        private static void GenerateReport()
        {
            InventoryRepository inventoryRepository = new InventoryRepository();
            TransactionRepository transactionRepository = new TransactionRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            ProductRepository productRepository = new ProductRepository();
            bool continueInventory = true;
            while (continueInventory)
            {
                Console.WriteLine("Generate Report:");
                Console.WriteLine("1. Inventory Details");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. List Suppliers");
                Console.WriteLine("4. List Transactions");
                Console.WriteLine("5. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        GenerateInventoryDetails(inventoryRepository);
                        break;
                    case 2:
                        ListProducts(productRepository);
                        break;
                    case 3:
                        ListSuppliers(supplierRepository);
                        break;
                    case 4:
                        ListTransactions(transactionRepository);
                        break;
                    case 5:
                        continueInventory = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            static void GenerateInventoryDetails(InventoryRepository inventoryRepository)
            {
                var inventoryList = inventoryRepository.ShowInventory();
                inventoryList.ForEach(inventory =>
                {
                    Console.WriteLine(inventory);
                    Console.WriteLine();
                    inventory.products.ForEach(product =>
                    {
                        Console.WriteLine(product);
                       
                        Console.WriteLine();
                    });

                    inventory.suppliers.ForEach(supplier =>
                    {
                        Console.WriteLine(supplier);
                        Console.WriteLine();

                    });
                    
                    inventory.transactions.ForEach(transaction =>
                    {
                        Console.WriteLine(transaction);
                        Console.WriteLine();
                    });

                    Console.WriteLine("================================================");
                });

            }
            static void ListProducts(ProductRepository productRepository)
            {
                var products = productRepository.GetAllProducts();
                Console.WriteLine("-------- List of Products --------");
                if (products.Count == 0)
                {
                    Console.WriteLine("No products available.");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                        Console.WriteLine("================================");
                    }
                }
            }

     
            static void ListSuppliers(SupplierRepository supplierRepository)
            {
                var suppliers = supplierRepository.GetAllSuppliers();
                Console.WriteLine("-------- List of Suppliers --------");
                if (suppliers.Count == 0)
                {
                    Console.WriteLine("No suppliers available.");
                }
                else
                {
                    foreach (var supplier in suppliers)
                    {
                        Console.WriteLine(supplier);
                        Console.WriteLine("================================");
                    }
                }
            }

            
            static void ListTransactions(TransactionRepository transactionRepository)
            {
                var transactions = transactionRepository.GetAll();
                Console.WriteLine("-------- List of Transactions --------");
                if (transactions.Count == 0)
                {
                    Console.WriteLine("No transactions available.");
                }
                else
                {
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine(transaction);
                        Console.WriteLine("================================");
                    }
                }
            }
        }
         public static void Exit()
            {
                Environment.Exit(0);
            }

        }
        }
    

    
    
        