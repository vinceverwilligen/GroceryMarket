using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMarket.Models
{
    /// <summary>
    /// Class <c>PointOfSaleTerminal</c> is the terminal which scans products.
    /// </summary>
    public class PointOfSaleTerminal
    {
        const string PRODUCT_WITH_CODE_NOT_FOUND = "Product with code {0} not found.";

        private Dictionary<Product, int> shoppingCart;
        /// <value>
        /// Property <c>Products</c> represents a dictionary of scanned products and the count.
        /// </value>
        public Dictionary<Product, int> ShoppingCart
        {
            get { return shoppingCart; }
            set { this.shoppingCart = value; }
        }

        /// <summary>
        /// This constructor creates a new terminal with empty <c>ShoppingCart</c>.
        /// </summary>
        public PointOfSaleTerminal()
        {
            this.shoppingCart = new Dictionary<Product, int>();
        }

        /// <summary>
        /// This method will scan a <c>Product</c> from the <c>GroceryStore</c> and add it to the <c>ShoppingCart</c>.
        /// </summary>
        /// <param name="code"><c>code</c> is the code of the product.</param>
        /// <param name="groceryStore"><c>groceryStore</c> contains the available products to scan.</param>
        /// <returns>The product that is scanned.</returns>
        /// <exception cref="Exception">Throws an exception if <c>Product</c> with <c>code</c> is not found.</exception>
        public Product ScanProduct(string code, GroceryStore groceryStore)
        {
            if (!groceryStore.Products.ContainsKey(code))
            {
                throw new Exception(String.Format(PRODUCT_WITH_CODE_NOT_FOUND, code));
            }

            Product product = groceryStore.Products[code];
            if (this.shoppingCart.ContainsKey(product))
            {
                this.shoppingCart[product] += 1;
            }
            else
            {
                this.shoppingCart.Add(product, 1);
            }

            return product;
        }

        /// <summary>
        /// This method scans multiple products after eachother.
        /// </summary>
        /// <param name="codes"><c>codes</c> is the list of codes that will be scanned.</param>
        /// <param name="groceryStore"><c>groceryStore</c> contains the available products to scan.</param>
        public void ScanProducts(string codes, GroceryStore groceryStore)
        {
            foreach(char code in codes)
            {
                ScanProduct(code.ToString(), groceryStore);
            }
        }

        /// <summary>
        /// This method will empty the <c>ShoppingCart</c>.
        /// </summary>
        public void CleanShoppingCart()
        {
            this.shoppingCart.Clear();
        }

        /// <summary>
        /// This method will calculate the total of all products in the <c>ShoppingCart</c>.
        /// </summary>
        /// <returns>The total price of the <c>ShoppingCart</c></returns>
        public double CalculateResult()
        {
            double total = 0;
            foreach (KeyValuePair<Product, int> kvp in this.ShoppingCart)
            {
                Product product = kvp.Key;
                int units = kvp.Value;

                total += product.CalculateProductPrice(units);
            }

            return total;
        }
    }
}
