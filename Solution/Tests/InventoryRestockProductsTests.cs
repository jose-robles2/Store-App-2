// <copyright file="StoreManager.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Final321.Backend;
using Final321.Backend.Products;

namespace Tests
{
    /// <summary>
    /// Tests for Final321.Backend.InventoryManager.RestockProducts()
    /// </summary>
    internal class InventoryRestockProductsTests
    {
        [Test]
        public void RestockProductsTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();
            
            string id = "1111";
            string description = "Item 1111";
            string type = "P";

            string id2 = "11111";
            string description2 = "Item 11111";
            string type2 = "P";

            string id3 = "111111";
            string description3 = "Item 111111";
            string type3 = "P";

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);

            inventoryManager.RestockProduct(id, 10);
            inventoryManager.RestockProduct(id2, 10);
            inventoryManager.RestockProduct(id3, 10);

            var products = inventoryManager.GetProducts();

            foreach (var productID in products.Keys)
            {
                Assert.That(products[productID].ItemCount, Is.EqualTo(10));
            }
        }

        [Test]
        public void RestockProductsTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111";
            string description = "Item 1111";
            string type = "P";

            string id2 = "11111";
            string description2 = "Item 11111";
            string type2 = "P";

            string id3 = "111111";
            string description3 = "Item 111111";
            string type3 = "P";

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);
            inventoryManager.RestockProduct(id, 10);
            inventoryManager.RestockProduct(id2, 11);
            inventoryManager.RestockProduct(id3, 10);

            inventoryManager.RestockAllProductsWithFlag(11, 10);
            var products = inventoryManager.GetProductsGreaterThan(11);

            foreach (var productID in products.Keys)
            {
                Assert.That(products[productID].ItemCount, Is.EqualTo(20));
            }
        }

        [Test]
        public void RestockProductsTest3()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111";
            string description = "Item 1111";
            string type = "P";

            string id2 = "11111";
            string description2 = "Item 11111";
            string type2 = "P";

            string id3 = "111111";
            string description3 = "Item 111111";
            string type3 = "P";

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);

            inventoryManager.RestockAllProducts(20);
            var products = inventoryManager.GetProducts();

            foreach (var productID in products.Keys)
            {
                Assert.That(products[productID].ItemCount, Is.EqualTo(20));
            }
        }
    }
}