// <copyright file="StoreManager.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.Backend;
using Store.Backend.Products;

namespace Tests
{
    /// <summary>
    /// Tests for Store.Backend.InventoryManager.GetProducts()
    /// </summary>
    internal class InventoryGetProductsTests
    {
        [Test]
        public void GetProductsTest1()
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

            var products = inventoryManager.GetProducts();

            Assert.That(products.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetProductsTest2()
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

            var products = inventoryManager.GetProductsGreaterThan(10);

            Assert.That(products.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetProductsTest3()
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

            var products = inventoryManager.GetProductsLessThan(11);

            Assert.That(products.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetElectronicProductsTest()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111";
            string description = "Item 1111";
            string type = "E";

            string id2 = "11111";
            string description2 = "Item 11111";
            string type2 = "E";

            string id3 = "111111";
            string description3 = "Item 111111";
            string type3 = "E";

            inventoryManager.AddProduct(id, description, type);
            inventoryManager.AddProduct(id2, description2, type2);
            inventoryManager.AddProduct(id3, description3, type3);
            inventoryManager.RestockProduct(id, 10);
            inventoryManager.RestockProduct(id2, 11);
            inventoryManager.RestockProduct(id3, 10);

            var products = inventoryManager.GetElectronicProducts();

            Assert.That(products.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetPhysicalProductsTest()
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

            var products = inventoryManager.GetPhysicalProducts();

            Assert.That(products.Count, Is.EqualTo(3));
        }
    }
}