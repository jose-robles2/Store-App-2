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
                    this.ViewInventoryOption();
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

            // fetch and show products less than N
            Dictionary<string, Product> products = this.storeManager.GetProductsLessThan(restockValue);

            if (products == null)
            {
                Console.WriteLine("Inventory is empty!");
                return;
            }

            foreach (var productID in products.Keys)
            {
                Console.WriteLine(products[productID].ToString());
            }

            Console.WriteLine("Would you like to restock all items? [Y or N]");
            char input = (char)Console.Read();
            string inputStr = input.ToString().ToUpper();

            if (inputStr == "Y")
            {
            }
            else if (inputStr == "N")
            {
            }

            // would you like to restock all of them?
                // yes-> display all info about each product less than N including stock count
                    // ask how much should they restock by (10 more, 20 more etc)
                        // show that restock success, show updated item info
                // no -> allow user to choose an individual item (in a loop, they can choose multiple one by one)
                    // when selecting an item, ask user if they want to restock this item Y/N
                        // yes -> ask how much should they restock by (10 more, 20 more etc)
                            // show that restock success, show updated item info
                        // no -> take them back one to where they can choose another item one by one to restock or not
        }

        private void ViewInventoryOption()
        {
            Console.WriteLine("/////////////////////////////////////");
            int counter = 1;
            foreach (var productId in this.storeManager.GetProducts().Keys)
            {
                Console.WriteLine("" + counter + ". " + this.storeManager.GetProducts()[productId].ToString());
                Console.WriteLine("/////////////////////////////////////");
                counter++;
            }
            this.PrepareNextUserInput();
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