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
    /// Tests for Final321.Backend.InventoryManager.AddProduct()
    /// </summary>
    internal class InventoryAddProductTests
    {
        [Test]
        public void AddProductTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();

            inventoryManager.AddProduct("1111", "Item 1111", "P");

            Assert.That(inventoryManager.IsInventoryEmpty(), Is.EqualTo(false));
        }

        [Test]
        public void AddProductTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            Product product = ProductFactory.Builder("2222", "Item 2222", Final321.Backend.Products.ProductType.Electronic);

            inventoryManager.AddProduct(product);

            Assert.That(inventoryManager.IsInventoryEmpty(), Is.EqualTo(false));
        }
    }
}
