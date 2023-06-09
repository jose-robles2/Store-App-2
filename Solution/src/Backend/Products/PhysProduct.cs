﻿// <copyright file="PhysProduct.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Store.Backend.Products
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
        /// <param name="itemCount"> count. </param>
        public PhysProduct(string id = "", string description = "", ProductType type = ProductType.Physical, int itemCount = 0)
            : base(id, description, type)
        {
            this.itemCount = itemCount;
        }

        /// <summary>
        /// Gets product type - needed for factory.
        /// </summary>
        public static ProductType ProductTypeStatic => ProductType.Physical;
    }
}
