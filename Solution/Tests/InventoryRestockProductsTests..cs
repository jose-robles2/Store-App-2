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
    /// Tests for Final321.Backend.InventoryManager.GetProducts()
    /// </summary>
    internal class InventoryGetProductsTests
    {
        [Test]
        public void GetProductsTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();

            int id = 1111;
            string description = "Item 1111";
            ProductType type = ProductType.Physical;

            int id2 = 11111;
            string description2 = "Item 11111";
            ProductType type2 = ProductType.Physical;

            int id3 = 111111;
            string description3 = "Item 111111";
            ProductType type3 = ProductType.Physical;

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);
            inventoryManager.RestockProduct(id, 10);
            inventoryManager.RestockProduct(id2, 11);
            inventoryManager.RestockProduct(id3, 10);

            var products = inventoryManager.GetProducts();

            Assert.That(products.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetProductsTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            int id = 1111;
            string description = "Item 1111";
            ProductType type = ProductType.Physical;

            int id2 = 11111;
            string description2 = "Item 11111";
            ProductType type2 = ProductType.Physical;

            int id3 = 111111;
            string description3 = "Item 111111";
            ProductType type3 = ProductType.Physical;

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);
            inventoryManager.RestockProduct(id, 10);
            inventoryManager.RestockProduct(id2, 11);
            inventoryManager.RestockProduct(id3, 10);

            var products = inventoryManager.GetProductsGreaterThan(10);

            Assert.That(products.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetProductsTest3()
        {
            InventoryManager inventoryManager = new InventoryManager();

            int id = 1111;
            string description = "Item 1111";
            ProductType type = ProductType.Physical;

            int id2 = 11111;
            string description2 = "Item 11111";
            ProductType type2 = ProductType.Physical;

            int id3 = 111111;
            string description3 = "Item 111111";
            ProductType type3 = ProductType.Physical;

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);
            inventoryManager.RestockProduct(id, 10);
            inventoryManager.RestockProduct(id2, 11);
            inventoryManager.RestockProduct(id3, 10);

            var products = inventoryManager.GetProductsLessThan(11);

            Assert.That(products.Count, Is.EqualTo(2));
        }
    }
}