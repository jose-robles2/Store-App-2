// <copyright file="Menu.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final321.Frontend
{
    /// <summary>
    /// Menu class that allows user to access the store inventory management app via console.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Menu is not ran automatically.
        /// </summary>
        private bool menuRunning = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
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
            Console.WriteLine("Welcome to your store inventory management app!");
            Console.WriteLine("Enter a menu option...");
            Console.WriteLine("1. Create a new product");
            Console.WriteLine("2. Search for a product");
            Console.WriteLine("3. Restock a product");
            Console.WriteLine("4. Quit");
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        private void CreateProductOption()
        {
        }

        /// <summary>
        /// Allow user to search a product.
        /// </summary>
        private void SearchProductOption()
        {
        }

        /// <summary>
        /// Allow user to restock a product.
        /// </summary>
        private void RestockProductOption()
        {
        }
    }
}
