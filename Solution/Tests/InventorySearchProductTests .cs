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
    /// Tests for Final321.Backend.InventoryManager.SearchProduct()
    /// </summary>
    internal class InventorySearchProductTests
    {
        [Test]
        public void SearchForAProductTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111", desc = "Item 1111", type = "P";

            inventoryManager.AddProduct(id, desc, type);

            Product product = inventoryManager.SearchForAProduct(id);

            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Description, Is.EqualTo(desc));
            Assert.That(product.ProductType, Is.EqualTo(ProductType.Physical));
        }

        [Test]
        public void SearchForAProductTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111", desc = "Item 1111", type = "P";

            string partialID = "11";

            inventoryManager.AddProduct(id, desc, type);

            Product product = inventoryManager.SearchForAProduct(partialID);

            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Description, Is.EqualTo(desc));
            Assert.That(product.ProductType, Is.EqualTo(ProductType.Physical));
        }
    }
}
