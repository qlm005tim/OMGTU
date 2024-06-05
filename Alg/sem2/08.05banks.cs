//Даны данные о банковских счетах клиентов
//Структура данных: номер счёта, ФИО, доход, расход, налог(5% с дохода, автоматически, исходя из дохода).
//Необходимо с использованием запросов отобрать клиентов с отрицательным балансом, 
  //посчитать количество клиентов с положительным балансом, выдать клиентов с максимальным доходом, посчитать общую сумму налогов
using System;
using System.Collections.Generic;
using System.Linq;

public class ClientAcc //class with person
{
  public int AccNum { get; set; }
  public string Name { get; set; }
  public decimal Income { get; set; }
  public decimal Expense { get; set; }
  public decimal Tax { get; set; }

  public decimal Balance 
  {
    get { return Income - Expense - Tax; }
  }
}

public class Program 
{
  public static void Main() 
  {
    List<ClientAcc> accounts = new List<ClientAcc> {
      new ClientAcc { AccNum = 1, Name = "Tom Smith", Income = 1200, Expense = 700 },
      new ClientAcc { AccNum = 2, Name = "Bob Karol", Income = 3000, Expense = 1900 },
      new ClientAcc { AccNum = 3, Name = "Sam White", Income = 7000, Expense = 2800 },
      new ClientAcc { AccNum = 4, Name = "Mary Smith", Income = 4800, Expense = 6500 },
      new ClientAcc { AccNum = 5, Name = "Kate Simpson", Income = 11000, Expense = 9990 },
      new ClientAcc { AccNum = 6, Name = "Max Ford", Income = 12000, Expense = 8000 }
    };
    foreach (var acc in accounts) 
    {
      acc.Tax = acc.Income * 0.05M;
    }

    Console.WriteLine("Клиенты с отрицательным балансом:");

    var negBalanceAcc = from account in accounts
      where account.Balance < 0
      select account;

    foreach (var account in negBalanceAcc) 
    {
      Console.WriteLine($"{account.Name} ({account.AccNum})");
    }

    

    var posBalanceAcc = from account in accounts
      where account.Balance > 0
      select account;
    Console.WriteLine($"Кол-во клиентов с положительным балансом: {posBalanceAcc.Count()}");

    

    var maxIncomeAcc = from account in accounts
      where account.Income == accounts.Max(a => a.Income)
      select account;

    Console.WriteLine($"Клиенты с максимальным доходом ({maxIncomeAcc.First().Income}):");

    foreach (var account in maxIncomeAcc) 
    {
      Console.WriteLine($"{account.Name} ({account.AccNum})");
    }

    
    var Taxes = from account in accounts
      select account.Tax;

    Console.WriteLine($"Общая сумма налогов: {Taxes.Sum()}");
  }
}
