// <copyright file="StoreMenu.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Final321.Backend;
using Final321.Backend.Products;

namespace Final321.Frontend
{
    /// <summary>
    /// Menu class that allows user to access the store inventory management app via console.
    /// </summary>
    internal class StoreMenu
    {
        /// <summary>
        /// Menu is not ran automatically.
        /// </summary>
        private bool menuRunning = true;

        /// <summary>
        /// Store manager to interact with the backend.
        /// </summary>
        private StoreManager storeManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMenu"/> class.
        /// </summary>
        public StoreMenu()
        {
            this.storeManager = new StoreManager();
        }

        /// <summary>
        /// Main loop for the console app.
        /// </summary>
        public void RunMenu()
        {
            while (this.menuRunning)
            {
                this.RenderMenu();
            }
        }

        /// <summary>
        /// Display the menu.
        /// </summary>
        private void RenderMenu()
        {
            Console.WriteLine("Welcome to the store inventory management app!");

            switch (this.GetMenuUserInput())
            {
                case 1:
                    this.CreateProductOption();
                    break;
                case 2:
                    this.SearchProductOption();
                    break;
                case 3:
                    this.RestockProductOption();
                    break;
                case 4:
                    this.PrintInventory(this.storeManager.GetProducts());
                    break;
                case 5:
                    this.menuRunning = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid int from 1-4\nPress any key to continue...");
                    Console.ReadLine();
                    break;
            }
        }

        /// <summary>
        /// Get user input for the menu.
        /// </summary>
        /// <returns> Integer. </returns>
        private int GetMenuUserInput()
        {
            Console.WriteLine("Enter a menu option...");
            Console.WriteLine("1. Create a new product");
            Console.WriteLine("2. Search for a product");
            Console.WriteLine("3. Restock a product");
            Console.WriteLine("4. View inventory");
            Console.WriteLine("5. Quit");
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        private void CreateProductOption()
        {
            Console.WriteLine("Enter new product ID: ");
            string? productID = Console.ReadLine();
            Console.WriteLine("Enter a new product description: ");
            string? productDesc = Console.ReadLine();
            Console.WriteLine("Electronic or physical? (Enter E or P)");
            string productType = Console.ReadLine();
            productType = productType.ToString().ToUpper();

            if (productID != null && productDesc != null && (productType == "E" || productType == "P"))
            {
                int res = this.storeManager.CreateProduct(productID, productDesc, productType);

                if (res == 0)
                {
                    Console.WriteLine("Product successfully created!");
                    this.PrepareNextUserInput();
                }
                else
                {
                    Console.WriteLine("Product unable to be created!");
                    this.PrepareNextUserInput();
                }
            }
        }

        /// <summary>
        /// Allow user to search a product.
        /// </summary>
        private void SearchProductOption()
        {
            // prompt user to search a sequence of characters
                // partial id search is allowed
                // keyword search allowed
                    // if input contains spaces, split into tokens -> AND seach or an OR search
                // display list of products that match the search
            // if input is an empty string, display all products
        }

        /// <summary>
        /// Allow user to restock a product.
        /// </summary>
        private void RestockProductOption()
        {
            Console.WriteLine("Enter a value n such that all products less than n it will be restocked:");
            int.TryParse(Console.ReadLine(), out int restockValue);

            Dictionary<string, Product> products = this.storeManager.GetProductsLessThan(restockValue);

            if (products == null || products.Count == 0)
            {
                Console.WriteLine("Inventory is empty!");
                this.PrepareNextUserInput();
                return;
            }

            this.PrintInventory(products);

            Console.WriteLine("Would you like to restock all items? [Y or N]");
            string input = Console.ReadLine();
            input = input.ToString().ToUpper();

            if (input == "Y")
            {
                this.HandleRestockAllProductsLessThanN(restockValue);
            }
            else if (input == "N")
            {
                this.HandleIndividualProductRestock();
            }
        }

        /// <summary>
        /// User enters "Y" to restock all products less than N, handle their input and restock.
        /// </summary>
        /// <param name="restockValue"> restock target. </param>
        private void HandleRestockAllProductsLessThanN(int restockValue)
        {
            Console.WriteLine("Enter the restock amount");
            int.TryParse(Console.ReadLine(), out int restockAmount);
            int res = this.storeManager.RestockAllProducts(restockValue, restockAmount);
            this.HandleRestockReturnValue(res);
        }

        /// <summary>
        /// User enters "N" so they will be prompted to restock individual.
        /// products. Handle their input and restock the product.
        /// </summary>
        private void HandleIndividualProductRestock()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an item to restock individually.");
                this.PrintInventory(this.storeManager.GetProducts());
                int label = this.storeManager.GetProducts().Count + 1;
                Console.WriteLine(label + ". Quit");
                int.TryParse(Console.ReadLine(), out int indexToRestock);

                string productID = this.GetProductIDFromIndex(indexToRestock);

                if (productID == string.Empty)
                {
                    return;
                }

                Console.WriteLine("Enter the restock amount");
                int.TryParse(Console.ReadLine(), out int restockAmount);
                int res = this.RestockWithProductID(productID, restockAmount);
                Console.Clear();
                this.HandleRestockReturnValue(res);

                Console.WriteLine("Would you like to restock another item? [Y or N]");
                string input = Console.ReadLine();
                input = input.ToString().ToUpper();

                if (input == "Y")
                {
                    continue;
                }
                else if (input == "N")
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Is the index valid, if yes a productID is returned.
        /// </summary>
        /// <param name="index"> index. </param>
        /// <returns> string. </returns>
        private string GetProductIDFromIndex(int index)
        {
            int i = 0;
            foreach (var productId in this.storeManager.GetProducts().Keys)
            {
                if (i == (index - 1))
                {
                    return productId;
                }

                i++;
            }

            return string.Empty;
        }

        /// <summary>
        /// Restock at an index.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="restockAmount"> amount. </param>
        /// <returns> success/failure int. </returns>
        private int RestockWithProductID(string productID, int restockAmount)
        {
            return this.storeManager.RestockAProduct(productID, restockAmount);
        }

        /// <summary>
        /// Display output after a restock.
        /// </summary>
        /// <param name="res"> result. </param>
        private void HandleRestockReturnValue(int res)
        {
            if (res == 0)
            {
                Console.WriteLine("Restock succesful!");
                this.PrintInventory(this.storeManager.GetProducts());
                this.PrepareNextUserInput();
            }
            else
            {
                Console.WriteLine("Restock unsuccessful! Something went wrong...");
            }
        }

        /// <summary>
        /// Print the inventory.
        /// </summary>
        /// <param name="products"> inventory being printed. </param>
        private void PrintInventory(Dictionary<string, Product> products)
        {
            Console.WriteLine("/////////////////////////////////////");
            int counter = 1;
            foreach (var productId in products.Keys)
            {
                Console.WriteLine(counter + ". " + products[productId].ToString());
                Console.WriteLine("/////////////////////////////////////");
                counter++;
            }
        }

        /// <summary>
        /// Pause then clear the screen.
        /// </summary>
        private void PrepareNextUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}