# GroceryMarket
This is an example of a Grocery Market

The repository contains 3 projects:
- [GroceryMarket](<./GroceryMarket>), which contains all models.
- [GroceryMarketTests](<./GroceryMarketTests>), which contains tests for the models.
- [GroceryMarketConsole](<./GroceryMarketConsole>), which contains a console app testing the models.

GroceryMarket
-------------
[GroceryMarket](<./GroceryMarket>) contains a [GroceryStore](<./GroceryMarket/Models/GroceryStore.cs>) which will store all products.
A [Product](<./GroceryMarket/Models/Product.cs>) contains List of [Price](<./GroceryMarket/Models/Price.cs>) object,
it should always contain a unit price and can have multiple units of volume prices.
The [PointOfSaleTerminal](<./GroceryMarket/Models/PointOfSaleTerminal.cs>) has a shopping cart of all products it can scan. Then it can calculate the final total price.

GroceryMarketTests
-----------------
[GroceryMarketTests](<./GroceryMarketTest>) has 2 test classes.
One for [GroceryStore](<./GroceryMarket/Models/GroceryStore.cs>) and another for [PointOfSaleTerminal](<./GroceryMarket/Models/PointOfSaleTerminal.cs>).
More test classes might be added in the future.

GroceryMarketConsole
--------------------
[GroceryMarketConsole](<./GroceryMarketConsole>) will open a command prompt,
showing the creation of the [GroceryStore](<./GroceryMarket/Models/GroceryStore.cs>)and [PointOfSaleTerminal](<./GroceryMarket/Models/PointOfSaleTerminal.cs>).
Then, it will simulate 3 times scanning of a set of of products.
