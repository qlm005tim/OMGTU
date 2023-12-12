using System;
using System.Collections.Generic;

class Product
{
public int[] SupplyDate { get; set; }
public int[] ManufacturingDate { get; set; }
public int Quantity { get; set; }
public double UnitPrice { get; set; }
public int[] SaleDate { get; set; }
public int QuantitySold { get; set; }
public string Name { get; set; }
public int ExpiryDays { get; set; }
}

class Warehouse
{
private List products = new List();

public void AddProduct(Product product)
{
products.Add(product);
}

public List GetExpiredProducts()
{
List expiredProducts = new List();
foreach (Product product in products)
{
int manufacturingDays = product.ManufacturingDate[1] * 30 + product.ManufacturingDate[0];
int expiryDate = manufacturingDays + product.ExpiryDays;
int supplyDays = product.SupplyDate[1] * 30 + product.SupplyDate[0];
if (supplyDays + expiryDate <= 60) // Assuming all months have 30 days
{
expiredProducts.Add(product);
}
}
return expiredProducts;
}

public double GetTotalSales(string productName)
{
double totalSales = 0;
foreach (Product product in products)
{
if (product.Name == productName)
{
totalSales += product.QuantitySold * product.UnitPrice;
}
}
return totalSales;
}
}

class Program
{
static void Main()
{
Warehouse warehouse = new Warehouse();

warehouse.AddProduct(new Product
{
SupplyDate = new int[] { 10, 5 }, // Supply date (day, month)
ManufacturingDate = new int[] { 5, 5 }, // Manufacturing date (day, month)
Quantity = 100,
UnitPrice = 10,
SaleDate = new int[] { 15, 5 }, // Sale date (day, month)
QuantitySold = 30,
Name = "Шоколад",
ExpiryDays = 45
});

warehouse.AddProduct(new Product
{
SupplyDate = new int[] { 15, 7 }, // Supply date (day, month)
ManufacturingDate = new int[] { 1, 7 }, // Manufacturing date (day, month)
Quantity = 50,
UnitPrice = 5,
SaleDate = new int[] { 20, 7 }, // Sale date (day, month)
QuantitySold = 20,
Name = "Печенье",
ExpiryDays = 30
});

List expiredProducts = warehouse.GetExpiredProducts();
Console.WriteLine("Товары с истекшим сроком годности:");
foreach (Product product in expiredProducts)
{
Console.WriteLine(product.Name);
}

double totalSales = warehouse.GetTotalSales("Шоколад");
Console.WriteLine("Общая сумма продажи шоколада: " + totalSales);
}
}
```

Эта программа создает объект `Warehouse`, представляющий склад магазина, а также классы `Product` и `SaleInfo` для хранения информации о товарах и продажах.

Метод `GetExpiredProducts` возвращает список товаров с истекшим сроком годности, а метод `GetTotalSales` возвращает общую сумму продажи определенного товара.