using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BL.BusinessObjects
{
    public class ProductRepository
    {
        /// <summary>
        /// Retrieve one Product
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            // TODO: Add Logic to retrive actually product

            // Temporary create testing product
            if (product.ProductId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted Sizes";
                product.CurrentPrice = 15.96M;
            }
            return product;
        }

        public List<Product> Retrieve()
        {
            return new List<Product>();
        }
        /// <summary>
        /// Saves current Product
        /// </summary>
        /// <returns></returns>
        public bool Save(Product product)
        {
            var success = true;
            if(product.HasChanges && product.IsValid)
            {
                if (product.IsNew)
                {
                    // call an insert stored procedure
                }
                else
                {
                    // call an update stored procedure
                }
            }
            return success;
        }

    }
}
