/*
На вход подаются данные в виде номера телефона, даты разговора, времени начала разговора, кол-ва минут
1) Необходимо выдать месячный отчёт по общей сумме минут каждого номера
Условия: данные ровно за один месяц, данные подаются в очередь,
чтобы подсчитать сумму минут необходимо с помощью словаря и хеш-таблицы (в качестве ключа - номер телефона, в качестве значения - кол-во минут),
на выходе выдать данные из словаря и из хеш-таблицы

2) Необходимо подсчитать суммарное время за каждую дату
Условия: данные ровно за один месяц, данные подаются в очередь,
чтобы подсчитать сумму минут необходимо с помощью словаря и хеш-таблицы (в качестве ключа - дата, в качестве значения - кол-во минут),
на выходе выдать данные из словаря и из хеш-таблицы
*/

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
    
  public static void Hashtable_answ()//метод с использованием хеш таблицы
  {
    Hashtable data = new Hashtable();

    Queue<string> queue = new Queue<string>();

    Console.WriteLine("Введите информацию по номерам, 'end' конец ввода");
    Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");

    string inf = Console.ReadLine();

    while (inf != "end") 
    {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");
      
      queue.Enqueue(inf);//информация по номеру добавляется в очередь

      inf = Console.ReadLine();
      
    }

    int ql=queue.Count;
    for (int i = 0; i < ql; i += 1) 
    {
      string str = queue.Dequeue();//строка с информацией по номеру
      string[] infs = str.Split();//массив с номером, дата...

      string phone_num = infs[0];
      double t = Convert.ToDouble(infs[3]);//колво минут

      if (data.ContainsKey(phone_num)) 
      {
        data[phone_num] = Convert.ToDouble(data[phone_num]) + t;
      } else 
      {
        data.Add(phone_num, t);
      }

      Console.WriteLine(str);//str
    }

    Console.WriteLine("Общая сумма минут разговора каждого номера:");

    foreach (DictionaryEntry phone in data) //цикл по очереди
    {
      Console.WriteLine($"{phone.Key}: {phone.Value} всего минут");
    }
  }



  public static void Dict_answ() 
  {
    var data = new Dictionary<string, double>();

    Queue<string> queue = new Queue<string>();

    Console.WriteLine("Введите информацию по номерам, 'end' конец ввода");
    Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");

    string inf = Console.ReadLine();//информация по номеру

    while (inf != "end") 
    {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");
      queue.Enqueue(inf);

      inf = Console.ReadLine();
    }
    
    int ql=queue.Count;
    for (int i = 0; i < ql; i += 1) 
    {
      string str = queue.Dequeue();//строка с информацией из очерди
      string[] infs = str.Split();//массив с информацией

      string phone_num = infs[0];
      double t = Convert.ToDouble(infs[3]);//время разговора

      if (data.ContainsKey(phone_num)) 
      {
        data[phone_num] = Convert.ToDouble(data[phone_num]) + t;
      } else {
        data.Add(phone_num, t);
      }

      Console.WriteLine(str);
    }

    Console.WriteLine("Общая сумма минут разговора каждого номера:");

    foreach (var phone in data)
    {
      Console.WriteLine($"{phone.Key}: {phone.Value} всего минут");
    }
  }


  public static void Main(string[] args) 
  {
    
    Console.WriteLine("Решение через хеш-таблицу");
    Hashtable_answ();
    Console.WriteLine("Решение через словарь");
    Dict_answ();
    
    }
  }




using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
    
  public static void Hashtable_answ()//метод с использованием хеш таблицы
  {
    Hashtable data = new Hashtable();

    Queue<string> queue = new Queue<string>();

    Console.WriteLine("Введите информацию по номерам, 'end' конец ввода");
    Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");

    string inf = Console.ReadLine();

    while (inf != "end") 
    {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");
      
      queue.Enqueue(inf);//информация по номеру добавляется в очередь

      inf = Console.ReadLine();
      
    }

    int ql=queue.Count;
    for (int i = 0; i < ql; i += 1) 
    {
      string str = queue.Dequeue();//строка с информацией по номеру
      string[] infs = str.Split();//массив с номером, дата...

      string date = infs[1];
      double t = Convert.ToDouble(infs[3]);//колво минут

      if (data.ContainsKey(date)) 
      {
        data[date] = Convert.ToDouble(data[date]) + t;
      } else 
      {
        data.Add(date, t);
      }

      Console.WriteLine(str);//str
    }

    Console.WriteLine("Общая сумма минут разговоров по каждой дате:");

    foreach (DictionaryEntry date in data) //цикл по очереди
    {
      Console.WriteLine($"{date.Key}: {date.Value} всего минут за дату");
    }
  }



  public static void Dict_answ() 
  {
    var data = new Dictionary<string, double>();

    Queue<string> queue = new Queue<string>();

    Console.WriteLine("Введите информацию по номерам, 'end' конец ввода");
    Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");

    string inf = Console.ReadLine();//информация по номеру

    while (inf != "end") 
    {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут разговора через пробел:");
      queue.Enqueue(inf);

      inf = Console.ReadLine();
    }
    
    int ql=queue.Count;
    for (int i = 0; i < ql; i += 1) 
    {
      string str = queue.Dequeue();//строка с информацией из очерди
      string[] infs = str.Split();//массив с информацией

      string date = infs[1];
      double t = Convert.ToDouble(infs[3]);//время разговора

      if (data.ContainsKey(date)) 
      {
        data[date] = Convert.ToDouble(data[date]) + t;
      } else {
        data.Add(date, t);
      }

      Console.WriteLine(str);
    }

    Console.WriteLine("Общая сумма минут разговора по каждой дате:");

    foreach (var date in data)
    {
      Console.WriteLine($"{date.Key}: {date.Value} всего минут за дату");
    }
  }


  public static void Main(string[] args) 
  {
    
    Console.WriteLine("Решение через хеш-таблицу");
    Hashtable_answ();
    Console.WriteLine("Решение через словарь");
    Dict_answ();
    
    }
  }
