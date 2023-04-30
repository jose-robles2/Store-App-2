// <copyright file="IProductLoader.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.Backend.Products;

namespace Store.Backend.SaveLoadFormats
{
    /// <summary>
    /// Interface for loading and saving inventory into different formats.
    /// </summary>
    public interface IProductLoader
    {
        /// <summary>
        /// Save to a file.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <param name="products"> products. </param>
        public void Save(Stream stream, Dictionary<string, Product> products);

        /// <summary>
        /// Load from a file.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <returns> spreadsheet. </returns>
        Dictionary<string, Product> Load(Stream stream);
    }
}
