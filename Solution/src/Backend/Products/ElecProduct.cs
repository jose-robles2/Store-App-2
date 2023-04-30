// <copyright file="ElecProduct.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Backend.Products
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
        /// <param name="type"> type. </param>
        /// <param name="itemCount"> count, will always be "infinite". </param>
        public ElecProduct(string id = "", string description = "", ProductType type = ProductType.Physical, int itemCount = 0)
            : base(id, description, type)
        {
            this.itemCount = int.MaxValue;
        }

        /// <summary>
        /// Gets product type - needed for factory.
        /// </summary>
        public static ProductType ProductTypeStatic => ProductType.Electronic;
    }
}