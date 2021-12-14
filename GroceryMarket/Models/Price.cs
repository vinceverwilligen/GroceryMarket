using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMarket.Models
{
    /// <summary>
    /// Class <c>Price</c> contains the price for the certain units of volume.
    /// </summary>
    public class Price
    {
        private int units;
        /// <value>
        /// Property <c>Units</c> is the units of volume of a product.
        /// </value>
        public int Units
        {
            get { return this.units; }
            set { this.units = value; }
        }

        private double value;
        /// <value>
        /// Property <c>value</c> represents the price for the <c>Units</c> of volume for a product.
        /// </value>
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// This constructor creates a <c>Price</c> object for given <c>units</c> of volume and price <c>value<c/>.
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        public Price(int units, double value)
        {
            this.units = units;
            this.value = value;
        }
    }
}
