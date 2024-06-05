//Последняя задача по алгоритмизации на 2 семестр:

//Содержатся сведения о производстве товаров работниками (табельный номер, ФИО сотрудника, 
//должность, зарплата, категория товара, кол-во произведённых товаров, цена за единицу товара)

//Необходимо определить:
//1) Кол-во рабочих, которые получают ЗП < сумма выработанной продукции
//2) Кол-во произведённой продукции по каждой категории (в количественном и денежном эквиваленте)
//3) Общий суммарный объём произведённой продукции
//4) Кол-во сотрудников, получающих > 50% от суммы производимого ими продукта
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class EmpInform
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Profit { get; set; }
    public string ProductCategory { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}


class Program
{
    static void Main()
    {
        List<EmpInform> empinforms = new List<EmpInform>
        {
            new EmpInform { EmployeeId = 1, Name = "Tim Smith", Position = "Worker", Profit = 1000m, ProductCategory = "Category2", Quantity = 10, Price = 20.5m },
            new EmpInform { EmployeeId = 2, Name = "Bill White", Position = "Worker", Profit= 10m, ProductCategory = "Category1", Quantity = 5, Price = 10.0m },
            new EmpInform { EmployeeId = 3, Name = "Julia Ais", Position = "Worker", Profit = 4000m, ProductCategory = "Category1", Quantity = 15, Price = 45.0m },
            new EmpInform { EmployeeId = 4, Name = "Nik Stone", Position = "Worker", Profit= 2500m, ProductCategory = "Category2", Quantity = 5, Price = 50.0m },
        };

        int empWithProfitlower = empinforms
            .Count(p => p.Profit < p.Quantity * p.Price);
        Console.WriteLine($"Кол-во сотрудников, которые получают ЗП < суммы выработанной продукции: {empWithProfitlower}");
        Console.WriteLine();

        var CategProduction = empinforms
            .GroupBy(p => p.ProductCategory)
            .Select(g => new { Category = g.Key, Quantity = g.Sum(p => p.Quantity), Totalprice = g.Sum(p => p.Quantity * p.Price) });
        foreach (var item in CategProduction)
        {
            Console.WriteLine($"Категория {item.Category}: {item.Quantity} шт. ({item.Totalprice})");
        }
        Console.WriteLine();

        decimal totalQuantitylprod = empinforms.Sum(p => p.Quantity);
        decimal totalProductprice = empinforms.Sum(p => p.Quantity * p.Price);
        Console.WriteLine("Общий суммарный объём произведённой продукции:");
        Console.WriteLine($"В количественном эквиваленте: {totalQuantitylprod}");
        Console.WriteLine($"В денежном эквиваленте: {totalProductprice}");
        Console.WriteLine();

        int empWithProfitmore = empinforms
            .Count(p => p.Profit > p.Quantity * p.Price * 0.5m);
        Console.WriteLine($"Кол-во сотрудников, получающих > 50% от суммы производимого ими продукта: {empWithProfitmore}");
    }
}