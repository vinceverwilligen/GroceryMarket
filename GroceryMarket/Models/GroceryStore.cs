using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMarket.Models
{
    /// <summary>
    /// Class <c>GroceryStore</c> contains the available products that the customers can buy.
    /// </summary>
    public class GroceryStore
    {
        private const string PRODUCT_WITH_CODE_NOT_FOUND = "Product with code {0} not found.";

        private Dictionary<string, Product> products;
        /// <value>
        /// Property <c>Products</c> represents a list of all available products.
        /// </value>
        public Dictionary<string, Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        /// <summary>
        /// This constructors creates a <c>GroceryStore</c> object with an empty list of products.
        /// </summary>
        public GroceryStore()
        {
            this.products = new Dictionary<string, Product>();
        }

        /// <summary>
        /// This method will add a new product to the list of products.
        /// </summary>
        /// <param name="code"><c>code</c> is the code of the new product.</param>
        /// <param name="name"><c>name</c> is the name of the new product.</param>
        /// <param name="unitPrice"><c>unitPrice</c> is the unit price of the new product.</param>
        /// <returns>The new product that is added to the product list.</returns>
        public Product AddProduct(string code, string name, double unitPrice)
        {
            Product product = new Product(code, name, unitPrice);

            this.products.Add(code, product);

            return product;

        }

        /// <summary>
        /// This method will set the price for the given amount of units.
        /// </summary>
        /// <param name="code"><c>code</c> is the code of the product.</param>
        /// <param name="price"><c>price</c> is the new price for the volume.</param>
        /// <param name="units"><c>units</c> is the volume for which the price is set.</param>
        /// <returns>The product with the updated or new volume price.</returns>
        /// <exception cref="Exception">Throws an exception if <c>Product</c> with <c>code</c> is not found.</exception>
        public Product SetPricing(string code, double price, int units = 1)
        {
            if (!this.products.ContainsKey(code))
            {
                throw new Exception(string.Format(PRODUCT_WITH_CODE_NOT_FOUND, code));
            }

            Product product = this.products[code];
            product.SetVolumePrice(price, units);

            return product;
        }

        /// <summary>
        /// This method gets the price of the product with <c>code</c> and volume of <c>units</c>.
        /// </summary>
        /// <param name="code"><c>code</c> is the code of the product.</param>
        /// <param name="units"><c>units</c> is the volume of the product.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws an exception if <c>Product</c> with <c>code</c> is not found.</exception>
        public double GetPricing(string code, int units = 1)
        {
            if (!this.products.ContainsKey(code))
            {
                throw new Exception(string.Format(PRODUCT_WITH_CODE_NOT_FOUND, code));
            }

            return this.products[code].GetVolumePrice(units);
        }
    }
}
