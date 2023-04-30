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
    /// Tests for Store.Backend.InventoryManager.SearchProduct()
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

            Assert.That(product.Id, Is.EqualTo(id.ToLower()));
            Assert.That(product.Description, Is.EqualTo(desc.ToLower()));
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

            Assert.That(product.Id, Is.EqualTo(id.ToLower()));
            Assert.That(product.Description, Is.EqualTo(desc.ToLower()));
            Assert.That(product.ProductType, Is.EqualTo(ProductType.Physical));
        }

        [Test]
        public void AndSearchForProductsTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111", desc = "This is Item 1111", type = "P";
            string id2 = "2222", desc2 = "This is Item 2222", type2 = "P";
            string id3 = "3333", desc3 = "This is Item 3333", type3 = "E";

            inventoryManager.AddProduct(id, desc, type);
            inventoryManager.AddProduct(id2, desc2, type2);
            inventoryManager.AddProduct(id3, desc3, type3);

            string[] searchTerms = { "1111", "This is" };

            Dictionary<string, Product> products = inventoryManager.SearchProductsAND(searchTerms);

            Assert.That(products.Count, Is.EqualTo(1));
            Assert.That(products[id].Id, Is.EqualTo(id.ToLower()));
            Assert.That(products[id].Description, Is.EqualTo(desc.ToLower()));
            Assert.That(products[id].ProductType, Is.EqualTo(ProductType.Physical));
        }

        [Test]
        public void AndSearchForProductsTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111", desc = "This is Item 1111", type = "P";
            string id2 = "2222", desc2 = "This is Item 2222", type2 = "P";
            string id3 = "3333", desc3 = "This is Item 3333", type3 = "E";

            inventoryManager.AddProduct(id, desc, type);
            inventoryManager.AddProduct(id2, desc2, type2);
            inventoryManager.AddProduct(id3, desc3, type3);

            string[] searchTerms = { "2222", "Item 22" };

            Dictionary<string, Product> products = inventoryManager.SearchProductsAND(searchTerms);

            Assert.That(products.Count, Is.EqualTo(1));
            Assert.That(products[id2].Id, Is.EqualTo(id2.ToLower()));
            Assert.That(products[id2].Description, Is.EqualTo(desc2.ToLower()));
            Assert.That(products[id2].ProductType, Is.EqualTo(ProductType.Physical));
        }

        [Test]
        public void OrSearchForProductsTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111", desc = "This is Item 1111", type = "P";
            string id2 = "2222", desc2 = "This is Item 2222", type2 = "P";
            string id3 = "3333", desc3 = "This is Item 3333", type3 = "E";

            inventoryManager.AddProduct(id, desc, type);
            inventoryManager.AddProduct(id2, desc2, type2);
            inventoryManager.AddProduct(id3, desc3, type3);

            string[] searchTerms = { "2222", "Item" };

            Dictionary<string, Product> products = inventoryManager.SearchProductsOR(searchTerms);

            Assert.That(products.Count, Is.EqualTo(3));


            Assert.That(products[id].Id, Is.EqualTo(id.ToLower()));
            Assert.That(products[id].Description, Is.EqualTo(desc.ToLower()));
            Assert.That(products[id].ProductType, Is.EqualTo(ProductType.Physical));

            Assert.That(products[id2].Id, Is.EqualTo(id2.ToLower()));
            Assert.That(products[id2].Description, Is.EqualTo(desc2.ToLower()));
            Assert.That(products[id2].ProductType, Is.EqualTo(ProductType.Physical));

            Assert.That(products[id3].Id, Is.EqualTo(id3.ToLower()));
            Assert.That(products[id3].Description, Is.EqualTo(desc3.ToLower()));
            Assert.That(products[id3].ProductType, Is.EqualTo(ProductType.Electronic));
        }

        [Test]
        public void OrSearchForProductsTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id = "1111", desc = "This is Item 1111", type = "P";
            string id2 = "2222", desc2 = "This is Item 2222", type2 = "P";
            string id3 = "3333", desc3 = "This is Item 3333", type3 = "E";

            inventoryManager.AddProduct(id, desc, type);
            inventoryManager.AddProduct(id2, desc2, type2);
            inventoryManager.AddProduct(id3, desc3, type3);

            string[] searchTerms = { "333", "This is" };

            Dictionary<string, Product> products = inventoryManager.SearchProductsOR(searchTerms);

            Assert.That(products[id].Id, Is.EqualTo(id.ToLower()));
            Assert.That(products[id].Description, Is.EqualTo(desc.ToLower()));
            Assert.That(products[id].ProductType, Is.EqualTo(ProductType.Physical));

            Assert.That(products[id2].Id, Is.EqualTo(id2.ToLower()));
            Assert.That(products[id2].Description, Is.EqualTo(desc2.ToLower()));
            Assert.That(products[id2].ProductType, Is.EqualTo(ProductType.Physical));

            Assert.That(products[id3].Id, Is.EqualTo(id3.ToLower()));
            Assert.That(products[id3].Description, Is.EqualTo(desc3.ToLower()));
            Assert.That(products[id3].ProductType, Is.EqualTo(ProductType.Electronic));
        }
    }
}