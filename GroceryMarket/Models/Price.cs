using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMarket.Models
{
    /// <summary>
    /// Class <c>Price</c> contains the price for the certain amount of unit.
    /// </summary>
    public class Price
    {
        private int units;
        /// <value>
        /// Property <c>Units</c> is the amount of products the price <c>value</c> represents.
        /// </value>
        public int Units
        {
            get { return this.units; }
            set { this.units = value; }
        }

        private double value;
        /// <value>
        /// Property <c>value</c> represents the price for the amount of <c>Units</c> of products.
        /// </value>
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// This constructor creates a <c>Price</c> object for given <c>units</c> and price <c>value<c/>.
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
