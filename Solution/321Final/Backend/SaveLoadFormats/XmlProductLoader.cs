// <copyright file="XmlProductLoader.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final321.Backend.Products;

namespace Final321.Backend.SaveLoadFormats
{
    /// <summary>
    /// Xml save/load class that implements interface.
    /// </summary>
    internal class XmlProductLoader : IProductLoader
    {
        /// <summary>
        /// Save/write to a file using xml.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <param name="products"> products. </param>
        public void Save(Stream stream, List<Product> products)
        {
        }

        /// <summary>
        /// Load to a file using xml.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <returns> list of products. </returns>
        public List<Product>? Load(Stream stream)
        {
            return null;
        }
    }
}
