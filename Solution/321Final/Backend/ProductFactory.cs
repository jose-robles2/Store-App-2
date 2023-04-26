// <copyright file="ProductFactory.cs" company="Jose Robles">
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
        /// <param name="type"> Type of product. </param>
        private delegate void OnProduct(ProductType productType, Type type);

        /// <summary>
        /// Static Builder method. Factory returns a Product obj that 
        /// contains a specialized product as it's dynamic type.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="productDesc"> desc. </param>
        /// <param name="productType">enum type. </param>
        /// <param name="itemCount"> itemCount. </param>
        /// <returns> Product. </returns>
        /// <exception cref="Exception"> unknown product. </exception>
        public static Product Builder(string productID, string productDesc, ProductType productType, int itemCount = 0)
        {
            InitFactory();
            if (SupportedProducts.ContainsKey(productType))
            {
                Type type = SupportedProducts[productType];
                ConstructorInfo? constructor = type.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(ProductType), typeof(int) });

                if (constructor != null)
                {
                    // Create an instance of the type using the constructor and the parameters
                    object? productObject = constructor.Invoke(new object[] { productID, productDesc, productType, itemCount });

                    if (productObject != null && productObject is Product)
                    {
                        return (Product)productObject;
                    }
                }
            }

            throw new Exception("Unknown Product type.");
        }

        /// <summary>
        /// Static Builder method. Factory returns a Product obj that 
        /// contains a specialized product as it's dynamic type.
        /// </summary>
        /// <param name="productID"> id. </param>
        /// <param name="productDesc"> desc. </param>
        /// <param name="productType"> string type. </param>
        /// <param name="itemCount"> itemCount. </param>
        /// <returns> Product. </returns>
        /// <exception cref="Exception"> unknown product. </exception>
        public static Product Builder(string productID, string productDesc, string productType, int itemCount = 0)
        {
            ProductType productTypeEnum = new ProductType();

            if (productType == "E" || productType == "P")
            {
                productTypeEnum = productType == "E" ? ProductType.Electronic : ProductType.Physical;
            }
            else if (productType == "electronic" || productType == "physical")
            {
                productTypeEnum = productType == "electronic" ? ProductType.Electronic : ProductType.Physical;
            }
            else if (productType == "ELECTRONIC" || productType == "PHYSICAL")
            {
                productTypeEnum = productType == "ELECTRONIC" ? ProductType.Electronic : ProductType.Physical;
            }

            InitFactory();
            if (SupportedProducts.ContainsKey(productTypeEnum))
            {
                Type type = SupportedProducts[productTypeEnum];
                ConstructorInfo? constructor = type.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(ProductType), typeof(int) });

                if (constructor != null)
                {
                    // Create an instance of the type using the constructor and the parameters
                    object? productObject = constructor.Invoke(new object[] { productID, productDesc, productTypeEnum, itemCount });

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
        /// Initialize the factory by checking for supported products to be added to the dictionary.
        /// </summary>
        private static void InitFactory()
        {
            OnProduct onProduct = (prod, type) => SupportedProducts.Add(prod, type);
            TraverseAvailableProducts(onProduct);
        }

        /// <summary>
        /// Utilize assembly reflection to search for supported prods by grabbing all subclasses of the Operator class.
        /// </summary>
        /// <param name="onProduct"> delegate. </param>
        private static void TraverseAvailableProducts(OnProduct onProduct)
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