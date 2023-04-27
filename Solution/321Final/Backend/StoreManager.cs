// <copyright file="StoreManager.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final321.Backend.Products;

namespace Final321.Backend
{
    /// <summary>
    /// Store manager controller object.
    /// </summary>
    internal class StoreManager
    {
        /// <summary>
        /// Manager object to access inventory.
        /// </summary>
        private InventoryManager inventoryManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreManager"/> class.
        /// </summary>
        public StoreManager()
        {
            this.LoadInventory();
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="productDesc"> description. </param>
        /// <param name="productTypeStr"> type. </param>
        /// <returns> int for success/failure. </returns>
        public int CreateProduct(string productID, string productDesc, string productTypeStr)
        {
            return this.inventoryManager.AddProduct(productID, productDesc, productTypeStr);
        }

        /// <summary>
        /// Search for product(s) via keywords.
        /// </summary>
        /// <param name="keywords"> list of keyword. </param>
        /// <returns> List of products. </returns>
        public Dictionary<string, Product> SearchProducts(string[] keywords, string andOR)
        {
            andOR = andOR.ToUpper();
            if (andOR == "AND")
            {
                return this.inventoryManager.SearchProductsAND(keywords);
            }
            else if (andOR == "OR")
            {
                return this.inventoryManager.SearchProductsOR(keywords);
            }

            return null;
        }

        /// <summary>
        /// Search for a product, return products matching the search.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <returns> List of products. </returns>
        public Product SearchForAProduct(string productID)
        {
            return this.inventoryManager.SearchForAProduct(productID);
        }

        /// <summary>
        /// Restock all physical products with less than some stock.
        /// </summary>
        /// <param name="restockTarget"> user input. </param>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockAllProducts(int restockTarget, int amountToRestock)
        {
            if (amountToRestock < 1)
            {
                return -1;
            }

            return this.inventoryManager.RestockAllProductsWithFlag(restockTarget, amountToRestock);
        }

        /// <summary>
        /// Restock all physical products.
        /// </summary>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockAllProducts(int amountToRestock)
        {
            if (amountToRestock < 1)
            {
                return -1;
            }

            return this.inventoryManager.RestockAllProducts(amountToRestock);
        }

        /// <summary>
        /// Restock all physical products.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockAProduct(string productID, int amountToRestock)
        {
            if (amountToRestock < 1)
            {
                return -1;
            }

            return this.inventoryManager.RestockProduct(productID, amountToRestock);
        }

        /// <summary>
        /// Fetch all products in inventory.
        /// </summary>
        /// <returns> list of products. </returns>
        public Dictionary<string, Product>? GetProducts()
        {
            return this.inventoryManager.GetProducts();
        }

        /// <summary>
        /// Fetch all products in inventory greater than n.
        /// </summary>
        /// <param name="n"> target. </param>
        /// <returns> list of products. </returns>
        public Dictionary<string, Product>? GetProductsGreaterThan(int n)
        {
            return this.inventoryManager.GetProductsGreaterThan(n);
        }

        /// <summary>
        /// Fetch all products in inventory less than n.
        /// </summary>
        /// <param name="n"> target. </param>
        /// <returns> list of products. </returns>
        public Dictionary<string, Product>? GetProductsLessThan(int n)
        {
            return this.inventoryManager.GetProductsLessThan(n);
        }

        /// <summary>
        /// Check if inventory empty.
        /// </summary>
        /// <returns> bool. </returns>
        public bool IsInventoryEmpty()
        {
            return this.inventoryManager.IsInventoryEmpty();
        }

        /// <summary>
        /// Load products into our inventory via an xml file saved in file explorer.
        /// </summary>
        private void LoadInventory()
        {
            string path = "inventory.xml";
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                this.inventoryManager = new InventoryManager(stream);
            }
        }
    }
}
