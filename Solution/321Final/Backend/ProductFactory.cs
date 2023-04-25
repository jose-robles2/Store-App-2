﻿// <copyright file="ProductFactory.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Final321.Backend.Products;

namespace Final321.Backend
{
    /// <summary>
    /// Factory object responsible for creating specialized products.
    /// </summary>
    public class ProductFactory
    {
        /// <summary>
        /// Static dictionary of supported types.
        /// </summary>
        private static readonly Dictionary<ProductType, Type> SupportedProducts = new Dictionary<ProductType, Type>();

        /// <summary>
        /// Delegate utilized for assembly reflection. Takes in a product and a type.
        /// </summary>
        /// <param name="productType"> product token. </param>
        /// <param name="type"> Type of operator. </param>
        private delegate void OnProduct(ProductType productType, Type type);

        /// <summary>
        /// Static Builder method. Factory returns a Product obj that 
        /// contains a specialized product as it's dynamic type.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="productDesc"> desc. </param>
        /// <param name="productType"> type. </param>
        /// <returns> Product. </returns>
        /// <exception cref="Exception"> unknown product. </exception>
        public static Product Builder(int productID, string productDesc, ProductType productType)
        {
            InitFactory();
            if (SupportedProducts.ContainsKey(productType))
            {
                Type type = SupportedProducts[productType];
                ConstructorInfo? constructor = type.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(ProductType)});

                if (constructor != null)
                {
                    // Create an instance of the type using the constructor and the parameters
                    object? productObject = constructor.Invoke(new object[] { productID, productDesc, productType}); 

                    if (productObject != null && productObject is Product)
                    {
                        return (Product)productObject;
                    }
                }
            }

            throw new Exception("Unknown Product type.");
        }

        /// <summary>
        /// Checks to see if the input token is supported.
        /// </summary>
        /// <param name="productType"> product. </param>
        /// <returns> bool. </returns>
        public static bool IsProductSupported(ProductType productType)
        {
            InitFactory();

            if (SupportedProducts.ContainsKey(productType))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initialize the factory by checking for supported operators to be added to the dictionary.
        /// </summary>
        private static void InitFactory()
        {
            OnProduct onProduct = (prod, type) => SupportedProducts.Add(prod, type);
            TraverseAvailableOperators(onProduct);
        }

        /// <summary>
        /// Utilize assembly reflection to search for supported ops by grabbing all subclasses of the Operator class.
        /// </summary>
        /// <param name="onProduct"> delegate. </param>
        private static void TraverseAvailableOperators(OnProduct onProduct)
        {
            Type productType = typeof(Product);
            IEnumerable<Type>? productTypes = null;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                productTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(productType));

                foreach (var type in productTypes)
                {
                    // For each subclass, retrieve the 'type' property
                    PropertyInfo? productField = type.GetProperty("ProductTypeStatic");
                    if (type != null)
                    {
                        // Get the static enum property
                        object? value = productField.GetValue(type);

                        if (value is ProductType)
                        {
                            ProductType productString = (ProductType)value;

                            if (!SupportedProducts.ContainsKey(productString))
                            {
                                onProduct(productString, type); // Invoke the delegate
                            }
                        }
                    }
                }
            }
        }
    }
}