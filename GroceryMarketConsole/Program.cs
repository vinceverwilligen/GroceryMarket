// See https://aka.ms/new-console-template for more information
using GroceryMarket.Models;

// Resources
const string CREATING_GROCERY_STORE = "Creating grocery store...";
const string CREATING_TERMINAL = "Creating point-of-sale terminal...";
const string LOADING_PRODUCTS = "Loading products...";
const string TERMINAL_IS_READY = "Point-of-sale Terminal is ready to scan items!";
const string TERMINAL_SCANNING_PRODUCTS = "Scanning the following items: {0}";
const string TERMINAL_TOTAL_PRICE = "Total price: {0:C2}";

// Creating Grocery Store
Console.WriteLine(CREATING_GROCERY_STORE);
GroceryStore groceryStore = new GroceryStore();

// Loading products
Console.WriteLine(LOADING_PRODUCTS);
groceryStore.AddProduct("A", "Apple", 1.25);
groceryStore.SetPricing("A", 3.0, 3);

groceryStore.AddProduct("B", "Bananna", 4.25);

groceryStore.AddProduct("C", "Coconut", 1.0);
groceryStore.SetPricing("C", 5.0, 6);

groceryStore.AddProduct("D", "Durian", 0.75);
Console.WriteLine();

// Creating Terminal
Console.WriteLine(CREATING_TERMINAL);
PointOfSaleTerminal terminal = new PointOfSaleTerminal();
Console.WriteLine(TERMINAL_IS_READY);
Console.WriteLine();

// Preparing codes
List<string> codes = new List<string>()
{
    "ABCDABA",
    "CCCCCCC",
    "ABCD"
};

// Scan codes
for (int i = 0; i < codes.Count; i++)
{
    Console.WriteLine(string.Format(TERMINAL_SCANNING_PRODUCTS, codes[i]));
    terminal.ScanProducts(codes[i], groceryStore);
    double total = terminal.CalculateResult();
    Console.WriteLine(string.Format(TERMINAL_TOTAL_PRICE, total));
    terminal.CleanShoppingCart();
    Console.WriteLine();
}

