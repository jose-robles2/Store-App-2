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
    /// Abstract product.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Unique product ID.
        /// </summary>
        protected readonly int id;

        /// <summary>
        /// Product description.
        /// </summary>
        protected readonly string description;

        /// <summary>
        /// Item count of a product.
        /// </summary>
        protected int itemCount;

        /// <summary>
        /// Type of product.
        /// </summary>
        protected ProductType productType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id"> id. </param>
        /// <param name="description"> description. </param>
        /// <param name="type"> type. </param>
        public Product(int id, string description, ProductType type)
        {
            this.id = id;
            this.description = description;
            this.productType = type;
        }

        /// <summary>
        /// Gets the ID.
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get { return this.description; }
        }

        /// <summary>
        /// Gets or sets the item count.
        /// </summary>
        public int ItemCount
        {
            get { return this.itemCount; }
            set { this.itemCount = value; }
        }

        /// <summary>
        /// Gets type of product - needed for instances.
        /// </summary>
        public ProductType ProductType
        {
            get { return this.productType; }
        }
    }
}
