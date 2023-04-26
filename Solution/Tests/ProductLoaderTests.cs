// <copyright file="Product.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using Final321.Backend.Products;
using Final321.Backend;
using Final321.Backend.SaveLoadFormats;

namespace Tests
{
    /// <summary>
    /// Tests for Final321.Backend.SaveLoadFormats.XmlProductLoader
    /// </summary>
    public class ProductLoaderTests
    {
        [Test]
        public void SaveLoadTest1()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id1 = "1111";
            string desc = "1111 desc";
            string type = "P";

            inventoryManager.AddProduct(id1, desc, type);

            // Create a MemoryStream to hold the XML data
            using (MemoryStream stream = new MemoryStream())
            {
                XmlProductLoader loader = new XmlProductLoader();
                loader.Save(stream, inventoryManager.GetProducts());

                stream.Position = 0;

                Dictionary<string, Product> result = loader.Load(stream);

                foreach (var id in result.Keys)
                {
                    Assert.That(result[id].Id, Is.EqualTo(inventoryManager.GetProducts()[id].Id));
                    Assert.That(result[id].Description, Is.EqualTo(inventoryManager.GetProducts()[id].Description));
                    Assert.That(result[id].ProductType, Is.EqualTo(inventoryManager.GetProducts()[id].ProductType));
                    Assert.That(result[id].ItemCount, Is.EqualTo(inventoryManager.GetProducts()[id].ItemCount));
                }
            }
        }

        [Test]
        public void SaveLoadTest2()
        {
            InventoryManager inventoryManager = new InventoryManager();

            string id1 = "1111";
            string desc = "1111 desc";
            string type = "P";

            string id2 = "2222";
            string desc2 = "2222 desc";
            string type2 = "P";

            string id3 = "3333";
            string desc3 = "3333 desc";
            string type3 = "P";

            string id4 = "4444";
            string desc4 = "4444 desc";
            string type4 = "P";

            inventoryManager.AddProduct(id1, desc, type);
            inventoryManager.AddProduct(id2, desc2, type2);
            inventoryManager.AddProduct(id3, desc3, type3);
            inventoryManager.AddProduct(id4, desc4, type4);

            // Create a MemoryStream to hold the XML data
            using (MemoryStream stream = new MemoryStream())
            {
                XmlProductLoader loader = new XmlProductLoader();
                loader.Save(stream, inventoryManager.GetProducts());

                stream.Position = 0;

                Dictionary<string, Product> result = loader.Load(stream);

                foreach (var id in result.Keys)
                {
                    Assert.That(result[id].Id, Is.EqualTo(inventoryManager.GetProducts()[id].Id));
                    Assert.That(result[id].Description, Is.EqualTo(inventoryManager.GetProducts()[id].Description));
                    Assert.That(result[id].ProductType, Is.EqualTo(inventoryManager.GetProducts()[id].ProductType));
                    Assert.That(result[id].ItemCount, Is.EqualTo(inventoryManager.GetProducts()[id].ItemCount));
                }
            }
        }
    }
}