using System;
class Product
{
public int[] SupplyDate { get; set; }
public int[] ManufactDate { get; set; }
public int Quantity { get; set; }
public double Price { get; set; }
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
int manufactDays = products[i].ManufactDate[1] * 30 + products[i].ManufactDate[0];
int expiryDate = manufactDays + products[i].ExpiryDays;
int supplyDays = products[i].SupplyDate[1] * 30 + products[i].SupplyDate[0];
if (supplyDays + expiryDate <= currentMonth * 30 + currentDay)
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
totalSales += products[i].QuantitySold * products[i].Price;
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
SupplyDate = new int[] { 10, 5 }, 
ManufactDate = new int[] { 5, 5 },
Quantity = 100,
Price = 10,
SaleDate = new int[] { 15, 5 },
QuantitySold = 30,
Name = "Молоко",
ExpiryDays = 45
});

warehouse.AddProduct(new Product
{
SupplyDate = new int[] { 15, 7}, 
ManufactDate = new int[] { 1, 7 },
Quantity = 50,
Price = 5,
SaleDate = new int[] { 20, 7 },
QuantitySold = 20,
Name = "кофе",
ExpiryDays = 30
});

Console.WriteLine("Товары с истекшим сроком годности:");
warehouse.GetExpiredProducts(15, 7);

double totalSales = warehouse.GetTotalSales("Молоко");
Console.WriteLine("Общая сумма продажи молока: " + totalSales);
}
}

