// <copyright file="Product.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using Final321.Backend.Products;
using Final321.Backend;

namespace Tests
{
    public class ProductFactoryTests
    {
        [Test]
        public void CreateElecProductTest()
        {
            int id = 1111;
            string description = "Item 1111";
            ProductType type = ProductType.Electronic;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Description, Is.EqualTo(description));
            Assert.That(ElecProduct.Type, Is.EqualTo(type));
        }

        [Test]
        public void CreateElecProductTest2()
        {
            int id = 2222;
            string description = "Item 2222";
            ProductType type = ProductType.Electronic;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Description, Is.EqualTo(description));
            Assert.That(ElecProduct.Type, Is.EqualTo(type));
        }

        [Test]
        public void CreatePhysProductTest()
        {
            int id = 3333;
            string description = "Item 3333";
            ProductType type = ProductType.Physical;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Description, Is.EqualTo(description));
            Assert.That(PhysProduct.Type, Is.EqualTo(type));
        }

        [Test]
        public void CreatePhysProductTest2()
        {
            int id = 4444;
            string description = "Item 4444";
            ProductType type = ProductType.Physical;

            Product product = ProductFactory.Builder(id, description, type);

            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Description, Is.EqualTo(description));
            Assert.That(PhysProduct.Type, Is.EqualTo(type));
        }
    }
}