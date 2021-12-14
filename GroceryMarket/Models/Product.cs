using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMarket.Models
{
    /// <summary>
    /// Class <c>Product</c> represents a product available in the <c>GroceryStore</c>.
    /// </summary>
    public class Product
    {

        const string PRODUCT_WITH_CODE_NO_PRICE_FOR_UNITS_OF_VOLUME_FOUND = "Product with code {0} does not contain {0} units of volume.";

        private string code;
        /// <value>
        /// Property <c>Code</c> is the code used for scanning the product.
        /// </value>
        public string Code
        {
            get { return code; }
            set { this.code = value; }
        }

        private string name;
        /// <value>
        /// Propery <c>name</c> is the name of the <c>Product</c>.
        /// </value>
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        private Dictionary<int, Price> prices;
        /// <value>
        /// The property <c>Prices</c> contains the unit price and all other units of volume prices.
        /// </value>
        public Dictionary<int, Price> Prices
        {
            get { return prices; }
            set { this.prices = value; }
        }

        /// <summary>
        /// This constructor will create a <c>Product</c> with <c>code</c>, <c>name</c> and <c>unitPrice</c>.
        /// </summary>
        /// <param name="code"><c>code</c> is the code of the <c>Product</c>.</param>
        /// <param name="name"><c>name</c> is the name of the <c>Product</c>.</param>
        /// <param name="unitPrice"><c>unitPrice</c> is the unit price of the <c>Product</c>.</param>
        public Product(string code, string name, double unitPrice)
        {
            this.code = code;
            this.name = name;
            this.prices = new Dictionary<int, Price>();
            SetUnitsOfVolumePrice(unitPrice, 1);
        }

        /// <summary>
        /// This method will set or update the <c>price</c> for the given volume of <c>units</c>.
        /// </summary>
        /// <param name="price">Is the new <c>price</c> of the <c>Product</c>.</param>
        /// <param name="units">Is the <c>units</c> of volume for the given price.</param>
        public void SetUnitsOfVolumePrice(double price, int units)
        {
            if (this.prices.ContainsKey(units))
            {
                this.prices[units].Value = price;
            }
            else
            {
                this.prices.Add(units, new Price(units, price));
            }
        }

        /// <summary>
        /// This method with find the price for the <c>units</c> of volume.
        /// </summary>
        /// <param name="units">The <c>units</c> of the <c>Product</c>.</param>
        /// <returns>Returns the price for the given <c>units</c> of volume.</returns>
        /// <exception cref="Exception">Not price found fot the given <c>units</c> of volume.</exception>
        public double GetVolumePrice(int units)
        {
            if (!this.prices.ContainsKey(units))
            {
                throw new Exception(string.Format(PRODUCT_WITH_CODE_NO_PRICE_FOR_UNITS_OF_VOLUME_FOUND, code, units));
            }

            return this.prices[units].Value;
        }

        /// <summary>
        /// Get the highest units of volume price available.
        /// </summary>
        /// <returns>The units of the volume.</returns>
        private int GetHighestVolume()
        {
            if (this.Prices.Count == 1)
            {
                return 1;
            }

            List<int> unitsList = this.prices.Keys.ToList();
            unitsList.Sort();
            return unitsList[unitsList.Count - 1];
        }

        /// <summary>
        /// Get the highest units of volume price available lower than given <c>units</c> of volume.
        /// </summary>
        /// <param name="units">The <c>units</c> of volume.</param>
        /// <returns>Returns the highest amount of units of volume lower than given <c>units</c> of volume.</returns>
        private int GetVolumeLowerThan(int units)
        {
            if (this.Prices.Count == 1 || units == 1)
            {
                return 1;
            }

            List<int> unitsList = this.prices.Keys.ToList();
            unitsList.Sort();

            int index = unitsList.IndexOf(units);
            return unitsList[index - 1];
        }
        /// <summary>
        /// This method calculate the total price for the given <c>units</c> of volume for a <c>Product</c>.
        /// </summary>
        /// <param name="units">The <c>units</c> of volume of the <c>Product</c>.</param>
        /// <returns>Return the total price of the <c>units</c> ofvolume for the <c>Product</c>.</returns>
        public double CalculateProductPrice(int units)
        {
            double total = 0;

            int count = units;
            int priceVolume = GetHighestVolume();
            while (count > 0)
            {
                if (priceVolume == count)
                {
                    total += this.prices[priceVolume].Value;
                    count -= priceVolume;
                }
                else if (priceVolume <= count)
                {
                    total += this.prices[priceVolume].Value;
                    count -= priceVolume;
                }
                else if (priceVolume > 1)
                {
                    priceVolume = GetVolumeLowerThan(priceVolume);
                }
            }

            return total;
        }
    }
}
