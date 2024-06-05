//moyka avto
//delegates
//interfaces for +-*/ root sin cos 19.03
 
using System;
using System.Linq;

interface IMethods 
{
  double Add(double a, double b);
  double Subtract(double a, double b);
  double Multiply(double a, double b);
  double Divide(double a, double b);
  double Root(double b, double e);
  double Sin(double n);
  double Cos(double n);
}

class Interfaces: IMethods 
{
  public double Add(double a, double b)//methods
  {
    return a + b;
  }

  public double Subtract(double a, double b) 
  {
    return a - b;
  }

  public double Multiply(double a, double b) 
  {
    return a * b;
  }

  public double Divide(double a, double b) 
  {
    if (b == 0) 
    {
      throw new Exception("Деление на 0");
    }
    return a / b;
  }

  public double Root(double b, double e) 
  {
    if (e % 2 == 0 && b < 0) 
    {
      throw new Exception("корень четной степени с отрицательным основанием");
    }
    return Math.Pow(b, 1.0 / e);
  }

  public double Cos(double n) 
  {
    return Math.Cos(n);
  }

    public double Sin(double n) 
  {
    return Math.Sin(n);
  }

  public delegate double Binary(double a, double b);//bin op
  public delegate double Unary(double n);//un op meth 1 arg

  public static void Main(string[] args) 
  {
    Interfaces obj = new Interfaces();

    Console.WriteLine("выбор операции ");
    Console.WriteLine("0 - Сложение");
    Console.WriteLine("1 - Вычитание");
    Console.WriteLine("2 - Умножение");
    Console.WriteLine("3 - Деление");
    Console.WriteLine("4 - Извлечение корня");
    Console.WriteLine("5 - Синус числа");
    Console.WriteLine("6 - Косинус числа");

    int com = Convert.ToInt32(Console.ReadLine());
    
    Binary bin = new Binary(obj.Add);//delegates
    
    Unary un = new Unary(obj.Sin);

    switch (com) {
      case 0: 
      {
        bin = new Binary(obj.Add);
        break;
      }
      case 1: {
        bin = new Binary(obj.Subtract);
        break;
      }
      case 2: 
      {
        bin = new Binary(obj.Multiply);
        break;
      }
      case 3: 
      {
        bin = new Binary(obj.Divide);
        break;
      }
      case 4: 
      {
        bin = new Binary(obj.Root);
        break;
      }
      case 5: 
      {
        un = new Unary(obj.Sin);
        break;
      }
      case 6: 
      {
        un = new Unary(obj.Cos);
        break;
      }
      default:
        Console.WriteLine("функции нет");
        break;
    }

    if (com >= 0 && com <= 4) 
    {
      Console.WriteLine("Введите два числа:");

      double a = Convert.ToDouble(Console.ReadLine());
      double b = Convert.ToDouble(Console.ReadLine());

      Console.WriteLine("Результат:");
      
      Console.WriteLine(bin(a, b));
    } 
    else if (com >= 5 && com <= 6) 
    {
      Console.WriteLine("Введите число:");

      double n = Convert.ToDouble(Console.ReadLine());

      Console.WriteLine("Результат:");
      
      Console.WriteLine(un(n));
    }
  }
}
