// <copyright file="InventoryManager.cs" company="Jose Robles">
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
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

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
        /// <param name="itemCount"> optional parameter to create items with a current stock count, not available to users. </param>
        /// <returns> int for success/failure. </returns
        public int AddProduct(string productID, string productDesc, string productType, int itemCount = 0)
        {
            Product product = ProductFactory.Builder(productID, productDesc, productType, itemCount);

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
        /// Search products with an AND. All keyword from the keywords must be.
        /// present in each product that is returned via searchedResults dictionary.
        /// </summary>
        /// <param name="keywords"> words to search. </param>
        /// <returns> Dict of products. </returns>
        public Dictionary<string, Product> SearchProductsAND(string[] keywords)
        {
            Dictionary<string, Product> searchResults = new Dictionary<string, Product>();

            foreach (KeyValuePair<string, Product> product in this.products)
            {
                bool allKeywordsPresent = false;
                foreach (string keyword in keywords)
                {
                    string keywordToLower = keyword.ToLower();
                    if (product.Key.Contains(keywordToLower) || product.Value.Description.Contains(keywordToLower))
                    {
                        allKeywordsPresent = true;
                    }
                    else
                    {
                        allKeywordsPresent = false;
                        break;
                    }
                }

                if (allKeywordsPresent && !searchResults.ContainsKey(product.Key))
                {
                    searchResults.Add(product.Key, product.Value);
                    allKeywordsPresent = false;
                }
            }

            return searchResults;
        }


        /// <summary>
        /// Search products with an OR. At least one keyword from the keywords must be. 
        /// present in each product that is returned via searchedResults dictionary.
        /// </summary>
        /// <param name="keywords"> words to search. </param>
        /// <returns> Dict of products. </returns>
        public Dictionary<string, Product> SearchProductsOR(string[] keywords)
        {
            Dictionary<string, Product> searchResults = new Dictionary<string, Product>();

            foreach (KeyValuePair<string, Product> product in this.products)
            {
                foreach (string keyword in keywords)
                {
                    string keywordToLower = keyword.ToLower();

                    if (product.Key.Contains(keywordToLower) || product.Value.Description.Contains(keywordToLower) && !searchResults.ContainsKey(product.Key))
                    {
                        searchResults.Add(product.Key, product.Value);
                    }
                }
            }

            return searchResults;
        }

        /// <summary>
        /// Search for an individual product. Input can be a partial id.
        /// </summary>
        /// <param name="productID"> id </param>
        /// <returns> product </returns>
        public Product SearchForAProduct(string productID)
        {
            try
            {
                return this.products[productID];
            }
            catch
            {
                // No exact match found, search for partial ID match
                foreach (string id in this.products.Keys)
                {
                    if (id.Contains(productID))
                    {
                        return this.products[id];
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Restock all phys products with no flag.
        /// </summary>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int. </returns>
        public int RestockAllProducts(int amountToRestock)
        {
                foreach (string productID in this.products.Keys)
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
            foreach (string productID in this.products.Keys)
            {
                try
                {
                    if (this.products[productID].ItemCount < restockNumber && this.products[productID].ProductType == ProductType.Physical)
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
        /// Restock an individual phys product.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="amountToRestock"> amount. </param>
        /// <returns> int for success/failure. </returns>
        public int RestockProduct(string productID, int amountToRestock)
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
        public Dictionary<string, Product> GetProducts()
        {
            return new Dictionary<string, Product>(this.products);
        }

        /// <summary>
        /// Fetch all products in inventory greater than n via deep copy.
        /// </summary>
        /// <param name="n"> target. </param>
        /// <returns> list of products. </returns>
        public Dictionary<string, Product>? GetProductsGreaterThan(int n)
        {
            Dictionary<string, Product>? productsCopy = new Dictionary<string, Product>();

            foreach (string productID in this.products.Keys)
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
        public Dictionary<string, Product>? GetProductsLessThan(int n)
        {
            Dictionary<string, Product>? productsCopy = new Dictionary<string, Product>();

            foreach (string prodID in this.products.Keys)
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