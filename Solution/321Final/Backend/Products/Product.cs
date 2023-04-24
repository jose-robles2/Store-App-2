// <copyright file="Product.cs" company="Jose Robles">
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
    /// Abstract product.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Unique product ID.
        /// </summary>
        protected readonly string id;

        /// <summary>
        /// Product description.
        /// </summary>
        protected readonly string description;

        /// <summary>
        /// Type of product.
        /// </summary>
        protected ProductType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id"> id. </param>
        /// <param name="description"> description. </param>
        /// <param name="type"> type. </param>
        public Product(string id, string description, ProductType type)
        {
            this.id = id;
            this.description = description;
            this.type = type;
        }

        /// <summary>
        /// Type of operator.
        /// </summary>
        public enum ProductType
        {
            /// <summary>
            /// Can have zero or more physical products.
            /// </summary>
            Physical,

            /// <summary>
            /// Can have unlimited electronic products.
            /// </summary>
            Electronic,
        }

        /// <summary>
        /// Gets the product type.
        /// </summary>
        public ProductType Type
        {
            get => this.type;
        }
    }
}
