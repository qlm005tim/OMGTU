//Даны сведения о товарах на складах (несколько!) компании (поля: артикул товара, наименование товара, категория товара, кол-во товара(на данном складе), 
//цена за единицу, склад размещения)
//С помощью запросов узнать:
//- объем товара в денежном эквиваленте по каждом складу
//- максимальную цену по каждой категории
//- среднюю цену товара по каждому складу и по всем складам (всех товаров на складе)
//- определить самый дешевый товар
//- вывести данные по складу, в котором наименьшая суммарная стоимость товаров (вывести все данные)
//Хранение данных: можно несколько классов, может быть один класс
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Product
{
    public int Article { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Sklad { get; set; }
}


class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Article = 1, Name = "Product1", Category = "Category 2", Quantity = 20, Price = 20.5, Sklad = "Sklad1" },
                new Product { Article = 2, Name = "Product2", Category = "Category 1", Quantity = 15, Price = 30.0, Sklad = "Sklad2" },
                new Product { Article = 3, Name = "Product3", Category = "Category 1", Quantity = 10, Price = 10.0, Sklad = "Sklad1" },
                new Product { Article = 4, Name = "Product4", Category = "Category 2", Quantity = 5, Price = 40.5, Sklad = "Sklad3" },
                new Product { Article = 5, Name = "Product5", Category = "Category 3", Quantity = 10, Price = 225.5, Sklad = "Sklad3" },
        };

        var skladTotalsale = products
            .GroupBy(p => p.Sklad)
            .Select(g => new { Sklad = g.Key, Totalsale = g.Sum(p => p.Quantity * p.Price) });
        foreach (var item in skladTotalsale)
        {
            Console.WriteLine($"Объем товаров в денежном эквиваленте на складе {item.Sklad}: {item.Totalsale}");
        }
        Console.WriteLine();

        var maxCategprice = products
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.Price) });
        foreach (var item in maxCategprice)
        {
            Console.WriteLine($"Максимальная цена в категории {item.Category}: {item.MaxPrice}");
        }
        Console.WriteLine();

        var avSkladprice = products
            .GroupBy(p => p.Sklad)
            .Select(g => new { Sklad = g.Key, AvPrice = g.Average(p => p.Price) });
        foreach (var item in avSkladprice)
        {
            Console.WriteLine($"Средняя цена товара по складу {item.Sklad}: {item.AvPrice} $");
        }
        Console.WriteLine();
        var avSklads = products.Average(p => p.Price);
        Console.WriteLine($"Средняя цена по всем складам: {avSklads} $");
        Console.WriteLine();

        var cheapProduct = products.OrderBy(p => p.Price).First();
        Console.WriteLine($"Самый дешевый товар по всем складам: {cheapProduct.Name} ({cheapProduct.Price} $)");
        Console.WriteLine();

        var minSklad = products
            .GroupBy(p => p.Sklad)
            .OrderBy(g => g.Sum(p => p.Quantity * p.Price))
            .First();

        Console.WriteLine($"Склад с минимальной суммарной стоимостью товаров: {minSklad.Key}");
        foreach (var item in minSklad)
        {
            Console.WriteLine($"{item.Article}: {item.Name} ({item.Quantity} x {item.Price} $)");
        }
    }
}