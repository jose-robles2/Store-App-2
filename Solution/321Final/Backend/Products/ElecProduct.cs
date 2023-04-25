// <copyright file="ElecProduct.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final321.Backend.Products
{
    /// <summary>
    /// Electronic product.
    /// </summary>
    public class ElecProduct : Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElecProduct"/> class.
        /// </summary>
        /// <param name="id"> id. </param>
        /// <param name="description"> description. </param>
        public ElecProduct(int id, string description)
            : base(id, description)
        {
            this.itemCount = int.MaxValue;
        }

        /// <summary>
        /// Gets type of product.
        /// </summary>
        public static ProductType Type => ProductType.Electronic;
    }
}