// <copyright file="Product.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using Store.Backend.Products;
using Store.Backend;

namespace Tests
{
    /// <summary>
    /// Tests for Store.Backend.ProductFactory.Builder()
    /// </summary>
    public class ProductFactoryTests
    {
        [Test]
        public void CreateElecProductTest()
        {
            string id = "1111";
            string description = "Item 1111";
            ProductType type = ProductType.Electronic;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id.ToLower()));
            Assert.That(product.Description, Is.EqualTo(description.ToLower()));
            Assert.That(product.ProductType, Is.EqualTo(type));
        }

        [Test]
        public void CreateElecProductTest2()
        {
            string id = "2222";
            string description = "Item 2222";
            ProductType type = ProductType.Electronic;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id.ToLower()));
            Assert.That(product.Description, Is.EqualTo(description.ToLower()));
            Assert.That(product.ProductType, Is.EqualTo(type));
        }

        [Test]
        public void CreatePhysProductTest()
        {
            string id = "3333";
            string description = "Item 3333";
            ProductType type = ProductType.Physical;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id.ToLower()));
            Assert.That(product.Description, Is.EqualTo(description.ToLower()));
            Assert.That(product.ProductType, Is.EqualTo(type));
        }

        [Test]
        public void CreatePhysProductTest2()
        {
            string id = "4444";
            string description = "Item 4444";
            ProductType type = ProductType.Physical;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id.ToLower()));
            Assert.That(product.Description, Is.EqualTo(description.ToLower()));
            Assert.That(product.ProductType, Is.EqualTo(type));
        }
    }
}