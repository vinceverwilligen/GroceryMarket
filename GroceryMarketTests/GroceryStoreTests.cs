using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Models;

namespace GroceryMarketTests
{
    [TestClass]
    public class GroceryStoreTests
    {
        private GroceryStore? groceryStore;

        [TestInitialize]
        public void SetUp()
        {
            groceryStore = new GroceryStore();

            groceryStore.AddProduct("A", "Apple", 1.25);
            groceryStore.SetPricing("A", 3.0, 3);

            groceryStore.AddProduct("B", "Bananna", 4.25);

            groceryStore.AddProduct("C", "Coconut", 1.0);
            groceryStore.SetPricing("C", 5.0, 6);

            groceryStore.AddProduct("D", "Durian", 0.75);
        }

        [TestMethod]
        public void SetPricing_WithUnitPrice_UpdatesUnitPrice()
        {
            Assert.IsNotNull(groceryStore);

            string code = "A";
            double price = 1.5;

            groceryStore.SetPricing(code, price);

            double actualPrice = groceryStore.GetPricing(code);
            Assert.AreEqual(price, actualPrice);
        }

        [TestMethod]
        public void SetPricing_WithVolumePrice_UpdatesVolumePrice()
        {
            Assert.IsNotNull(groceryStore);

            string code = "A";
            double price = 3.0;
            int volume = 3;

            groceryStore.SetPricing(code, price, volume);

            double actualPrice = groceryStore.GetPricing(code, volume);
            Assert.AreEqual(price, actualPrice);
        }
    }
}
