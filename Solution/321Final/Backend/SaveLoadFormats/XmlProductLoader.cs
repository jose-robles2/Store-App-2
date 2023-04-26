// <copyright file="XmlProductLoader.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Final321.Backend.Products;

namespace Final321.Backend.SaveLoadFormats
{
    /// <summary>
    /// Xml save/load class that implements interface.
    /// </summary>
    public class XmlProductLoader : IProductLoader
    {
        /// <summary>
        /// Save/write to a file using xml. Xmlwriter is utilized to create an xml structure of.
        /// <products>
        ///     <product>
        ///         <prodAttrN> </prodAttrN>
        ///     </product>
        /// </products>
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <param name="products"> products. </param>
        public void Save(Stream stream, Dictionary<string, Product> products)
        {
            XmlWriter xmlWriter = XmlWriter.Create(stream);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("products");

            foreach (var productID in products.Keys)
            {
                Product product = products[productID];
                xmlWriter.WriteStartElement("product");
                xmlWriter.WriteAttributeString("id", product.Id.ToString());

                xmlWriter.WriteStartElement("description");
                xmlWriter.WriteString(product.Description);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("productType");
                xmlWriter.WriteString(product.ProductType.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("itemCount");
                xmlWriter.WriteString(product.ItemCount.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
        }

        /// <summary>
        /// Load to a file using xml.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <returns> list of products. </returns>
        public Dictionary<string, Product> Load(Stream stream)
        {
            InventoryManager inventoryManager = new InventoryManager();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stream);

            XmlNode? xmlRootNode = xmlDocument.SelectSingleNode("products");

            if (xmlRootNode == null)
            {
                return null;
            }

            string id = string.Empty, description = string.Empty, productType = string.Empty, itemCountStr = string.Empty;
            int itemCount = 0;
            foreach (XmlNode childNode in xmlRootNode.ChildNodes)
            {
                XmlElement element = (XmlElement)childNode;

                if (element.Name != "product")
                {
                    continue;
                }

                id = element.GetAttribute("id");

                foreach (XmlNode nestedChildNode in childNode.ChildNodes)
                {
                    XmlElement childElement = (XmlElement)nestedChildNode;

                    if (childElement.Name == "description")
                    {
                        description = childElement.InnerText;
                    }
                    else if (childElement.Name == "productType")
                    {
                        productType = childElement.InnerText;
                    }
                    else if (childElement.Name == "itemCount")
                    {
                        itemCountStr = childElement.InnerText;
                        int.TryParse(itemCountStr, out itemCount);
                    }
                    else
                    {
                        continue;
                    }
                }
                inventoryManager.AddProduct(id, description, productType, itemCount);
            }

            return inventoryManager.GetProducts();
        }
    }
}