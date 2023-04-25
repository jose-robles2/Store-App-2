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
            this.inventoryManager = new InventoryManager();
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="productDesc"> description. </param>
        /// <param name="productTypeStr"> type. </param>
        /// <returns> int for success/failure. </returns>
        public int CreateProduct(int productID, string productDesc, string productTypeStr)
        {
            ProductType productTypeEnum = productTypeStr == "E" ? ProductType.Electronic : ProductType.Physical;

            return this.inventoryManager.AddProduct(productID, productDesc, productTypeEnum);
        }

        /// <summary>
        /// Search for a product, return products matching the search.
        /// </summary>
        /// <returns> List of products. </returns>
        public Dictionary<int, Product> SearchProduct()
        {
            return this.inventoryManager.SearchProduct();
        }

        /// <summary>
        /// Restock all physical products with less than some stock.
        /// </summary>
        /// <param name="restockTarget"> user input. </param>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockAllProducts(int restockTarget, int amountToRestock)
        {
            return this.inventoryManager.RestockAllProducts(restockTarget, amountToRestock);
        }

        /// <summary>
        /// Fetch all products in inventory.
        /// </summary>
        /// <returns> list of products. </returns>
        public Dictionary<int, Product>? GetProducts()
        {
            return this.inventoryManager.GetProducts();
        }
    }
}
