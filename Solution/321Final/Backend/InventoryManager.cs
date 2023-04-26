﻿// <copyright file="InventoryManager.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final321.Backend.Products;
using Final321.Backend.SaveLoadFormats;

namespace Final321.Backend
{
    /// <summary>
    /// Manages product interactions.
    /// </summary>
    public class InventoryManager
    {
        /// <summary>
        /// Products in inventory.
        /// </summary>
        private Dictionary<int, Product> products = new Dictionary<int, Product>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// </summary>
        public InventoryManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// Loads inventory data from a certain file.
        /// </summary>
        /// <param name="stream"> stream. </param>
        public InventoryManager(Stream stream)
        {
            XmlProductLoader loader = new XmlProductLoader();
            this.products = loader.Load(stream);
        }

        /// <summary>
        /// Create a new product and then add the new product to the inventory.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="productDesc"> desc. </param>
        /// <param name="productType"> type. </param>
        /// <returns> int for success/failure. </returns
        public int AddProduct(int productID, string productDesc, ProductType productType)
        {
            Product product = ProductFactory.Builder(productID, productDesc, productType);

            if (product == null)
            {
                return -1;
            }

            return this.AddProduct(product);
        }

        /// <summary>
        /// Add a new product to the inventory.
        /// </summary>
        /// <param name="product"> product. </param>
        /// <returns> int for success/failure. </returns>
        public int AddProduct(Product product)
        {
            try
            {
                this.products.Add(product.Id, product);
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Search a product.
        /// </summary>
        /// <returns> Dict of products. </returns>
        public Dictionary<int, Product> SearchProduct()
        {
            return null;
        }

        /// <summary>
        /// Restock all phys products with no flag.
        /// </summary>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int. </returns>
        public int RestockAllProducts(int amountToRestock)
        {
                foreach (int productID in this.products.Keys)
                {
                    try
                    {
                        if (this.products[productID].ProductType == ProductType.Physical)
                        {
                            this.RestockProduct(productID, amountToRestock);
                        }
                    }
                    catch
                    {
                        return -1;
                    }
                }

                return 0;
        }

        /// <summary>
        /// Restock all phys products with less item count than restockNumber.
        /// </summary>
        /// <param name="restockNumber"> number to check to restock. </param>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockAllProductsWithFlag(int restockNumber, int amountToRestock)
        {
            foreach (int productID in this.products.Keys)
            {
                try
                {
                    if (this.products[productID].ItemCount < restockNumber && this.products[productID].ProductType == ProductType.Physical)
                    {
                        this.RestockProduct(productID, amountToRestock);
                        return 0;
                    }
                }
                catch
                {
                    return -1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Restock an individual phys product.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockProduct(int productID, int amountToRestock)
        {
            try
            {
                if (this.products[productID].ProductType == ProductType.Physical)
                {
                    this.products[productID].ItemCount += amountToRestock;
                    return 0;
                }
            }
            catch
            {
                return -1;
            }

            return -1;
        }

        /// <summary>
        /// Fetch all products in inventory via deep copy.
        /// </summary>
        /// <returns> list of products. </returns>
        public Dictionary<int, Product> GetProducts()
        {
            return new Dictionary<int, Product>(this.products);
        }

        /// <summary>
        /// Fetch all products in inventory greater than n via deep copy.
        /// </summary>
        /// <param name="n"> target. </param>
        /// <returns> list of products. </returns>
        public Dictionary<int, Product>? GetProductsGreaterThan(int n)
        {
            Dictionary<int, Product>? productsCopy = new Dictionary<int, Product>();

            foreach (int productID in this.products.Keys)
            {
                if (this.products[productID].ItemCount > n)
                {
                    productsCopy.Add(productID, this.products[productID]);
                }
            }

            return productsCopy;
        }

        /// <summary>
        /// Fetch all products in inventory less than n via deep copy.
        /// </summary>
        /// <param name="n"> target. </param>
        /// <returns> list of products. </returns>
        public Dictionary<int, Product>? GetProductsLessThan(int n)
        {
            Dictionary<int, Product>? productsCopy = new Dictionary<int, Product>();

            foreach (int prodID in this.products.Keys)
            {
                if (this.products[prodID].ItemCount < n)
                {
                    productsCopy.Add(prodID, this.products[prodID]);
                }
            }

            return productsCopy;
        }

        /// <summary>
        /// Check if inventory empty.
        /// </summary>
        /// <returns> bool. </returns>
        public bool IsInventoryEmpty()
        {
            return this.products.Count == 0 ? true : false;
        }
    }
}