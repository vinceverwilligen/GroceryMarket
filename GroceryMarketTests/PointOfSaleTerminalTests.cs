using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryMarket.Models;

namespace GroceryMarketTests
{
    [TestClass]
    public class PointOfSaleTerminalTests
    {
        private GroceryStore groceryStore;
        private PointOfSaleTerminal terminal;

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

            terminal = new PointOfSaleTerminal();
        }

        [TestMethod]
        public void SetPricing_WithUnitPrice_UpdatesUnitPrice()
        {
            Assert.IsNotNull(groceryStore);
            Assert.IsNotNull(terminal);

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
            Assert.IsNotNull(terminal);

            string code = "A";
            double price = 3.0;
            int volume = 3;

            groceryStore.SetPricing(code, price, volume);

            double actualPrice = groceryStore.GetPricing(code, volume);
            Assert.AreEqual(price, actualPrice);
        }

        [TestMethod]
        public void ScanItem_WithCode_ShoppingCartUpdated()
        {
            Assert.IsNotNull(groceryStore);
            Assert.IsNotNull(terminal);

            string code = "A";

            Product product = terminal.ScanProduct(code, groceryStore);

            CollectionAssert.Contains(terminal.ShoppingCart.Keys, product);
        }

        [TestMethod]
        public void CalculateTotal_WithMultipleProducts_UpdatesCalculatedTotal()
        {
            Assert.IsNotNull(groceryStore);
            Assert.IsNotNull(terminal);

            string code1 = "A";
            string code2 = "B";
            string code3 = "C";
            Product product1 = terminal.ScanProduct(code1, groceryStore);
            Product product2 = terminal.ScanProduct(code2, groceryStore);
            Product product3 = terminal.ScanProduct(code3, groceryStore);

            double total = terminal.CalculateResult();

            double expected = 6.50;
            Assert.AreEqual(expected, total);
        }

        // 1. Scan these items in this order: ABCDABA
        // Verify that the total price is $13.25
        [TestMethod]
        public void CalculateTotal_WithMultipleProducts1_UsesVolumePricesForCalculatedTotal()
        {
            Assert.IsNotNull(groceryStore);
            Assert.IsNotNull(terminal);

            string codes = "ABCDABA";
            terminal.ScanProducts(codes, groceryStore);

            double total = terminal.CalculateResult();

            double expected = 13.25;
            Assert.AreEqual(expected, total);
        }

        // 2. Scan these items in this order: CCCCCCC
        // Verify that the total price is $6.00
        [TestMethod]
        public void CalculateTotal_WithMultipleProducts2_UsesVolumePricesForCalculatedTotal()
        {
            Assert.IsNotNull(groceryStore);
            Assert.IsNotNull(terminal);

            string codes = "CCCCCCC";
            terminal.ScanProducts(codes, groceryStore);

            double total = terminal.CalculateResult();

            double expected = 6.00;
            Assert.AreEqual(expected, total);
        }

        // 3. Scan these items in this order: ABCD
        // Verify that the total price is $7.25
        [TestMethod]
        public void CalculateTotal_WithMultipleProducts3_UsesVolumePricesForCalculatedTotal()
        {
            Assert.IsNotNull(groceryStore);
            Assert.IsNotNull(terminal);

            string codes = "ABCD";
            terminal.ScanProducts(codes, groceryStore);

            double total = terminal.CalculateResult();

            double expected = 7.25;
            Assert.AreEqual(expected, total);
        }
    }
}