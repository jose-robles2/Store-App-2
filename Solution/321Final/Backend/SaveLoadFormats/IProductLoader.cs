// <copyright file="IProductLoader.cs" company="Jose Robles">
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
    /// Interface for loading and saving inventory into different formats.
    /// </summary>
    internal interface IProductLoader
    {
        /// <summary>
        /// Save to a file.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <param name="products"> products. </param>
        void Save(Stream stream, List<Product> products);

        /// <summary>
        /// Load from a file.
        /// </summary>
        /// <param name="stream"> stream. </param>
        /// <returns> spreadsheet. </returns>
        List<Product>? Load(Stream stream);
    }
}
