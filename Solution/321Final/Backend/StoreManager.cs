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
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="id"> id. </param>
        /// <param name="desc"> description. </param>
        /// <param name="type"> type. </param>
        /// <returns> int. </returns>
        public int CreateProduct(int id, string desc, string type)
        {
            return 0;
        }

        /// <summary>
        /// Search for a product, return products matching the search.
        /// </summary>
        /// <returns> List of products. </returns>
        public List<Product>? SearchProduct()
        {
            return null;
        }

        /// <summary>
        /// Restock all physical products with less than some stock.
        /// </summary>
        /// <param name="restockTarget"> user input. </param>
        /// <returns> int. </returns>
        public int RestockProduct(int restockTarget)
        {
            return 0;
        }

        /// <summary>
        /// Fetch all products in inventory.
        /// </summary>
        /// <returns> list of products. </returns>
        public List<Product>? GetProducts()
        {
            return null;
        }
    }
}
