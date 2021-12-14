# GroceryMarket
This is an example of a Grocery Market

The repository contains 3 projects:
- [GroceryMarket](<./GroceryMarket>), which contains all models.
- [GroceryMarketTests](<./GroceryMarketTests>), which contains tests for the models.
- [GroceryMarketConsole](<./GroceryMarketConsole>), which contains a console app testing the models.

GroceryMarket
-------------
[GroceryMarket](<./GroceryMarket>) contains a [GroceryStore](<./Models/GroceryStore>) which will store all products.
A [Product](<./Models/Product>) contains List of [Price](<./Price>) object,
it should always contain a unit price and can have multiple units of volume prices.
The [PointOfSaleTerminal](<./PointOfSaleTerminal.cs>) has a shopping cart of all products it can scan. Then it can calculate the final total price.

GroceryMarketTests
-----------------
[GroceryMarketTests](<./GroceryMarketTest>) has 2 test classes.
One for [GroceryStore](<./Models/GroceryStore>) and another for [PointOfSaleTerminal](<./PointOfSaleTerminal.cs>).
More test classes might be added in the future.

GroceryMarketConsole
--------------------
[GroceryMarketConsole](<./GroceryMarketConsole>) will open a command prompt,
showing the creation of the [GroceryStore](<./Models/GroceryStore>)and [PointOfSaleTerminal](<./PointOfSaleTerminal.cs>).
Then, it will simulate 3 times scanning of a set of of products.
