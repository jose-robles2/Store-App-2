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
        /// <param name="type"> type. </param>
        public ElecProduct(int id, string description, ProductType type)
            : base(id, description, type)
        {
        }
    }
}
