using System;

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
private Product[] products = new Product[10];
private int productCount = 0;

public void AddProduct(Product product)
{
products[productCount] = product;
productCount++;
}

public void GetExpiredProducts(int currentDay, int currentMonth)
{
Console.WriteLine("Товары с истекшим сроком годности:");
for (int i = 0; i < productCount; i++)
{
int manufacturingDays = products[i].ManufacturingDate[1] * 30 + products[i].ManufacturingDate[0];
int expiryDate = manufacturingDays + products[i].ExpiryDays;
int supplyDays = products[i].SupplyDate[1] * 30 + products[i].SupplyDate[0];
if (supplyDays + expiryDate <= currentMonth * 30 + currentDay) // Assuming all months have 30 days
{
Console.WriteLine(products[i].Name);
}
}
}

public double GetTotalSales(string productName)
{
double totalSales = 0;
for (int i = 0; i < productCount; i++)
{
if (products[i].Name == productName)
{
totalSales += products[i].QuantitySold * products[i].UnitPrice;
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

Console.WriteLine("Товары с истекшим сроком годности:");
warehouse.GetExpiredProducts(15, 7);

double totalSales = warehouse.GetTotalSales("Шоколад");
Console.WriteLine("Общая сумма продажи шоколада: " + totalSales);
}
}


В этой программе используется массив `products` для хранения товаров на складе. Метод `GetExpiredProducts` возвращает товары с истекшим сроком годности, а метод `GetTotalSales` возвращает общую сумму продажи определенного товара.
