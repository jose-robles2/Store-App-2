// <copyright file="InventoryManager.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using Final321.Backend.Products;
using Final321.Backend.SaveLoadFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final321.Backend
{
    /// <summary>
    /// Manages product interactions.
    /// </summary>
    internal class InventoryManager
    {
        /// <summary>
        /// Products in inventory.
        /// </summary>
        private List<Product> products = new List<Product>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// </summary>
        public InventoryManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// Loads inventory data from a certain file.
        /// </summary>
        /// <param name="stream"> stream. </param>
        public InventoryManager(Stream stream)
        {
            XmlProductLoader loader = new XmlProductLoader();
            this.products = loader.Load(stream);
        }
    }
}
