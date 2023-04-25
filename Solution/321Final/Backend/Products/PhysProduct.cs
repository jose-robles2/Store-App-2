// <copyright file="PhysProduct.cs" company="Jose Robles">
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
    /// Physical product.
    /// </summary>
    public class PhysProduct : Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysProduct"/> class.
        /// </summary>
        /// <param name="id"> id. </param>
        /// <param name="description"> description. </param>
        /// <param name="type"> type. </param>
        public PhysProduct(int id, string description, ProductType type)
            : base(id, description, type)
        {
            this.itemCount = 0;
        }
    }
}
