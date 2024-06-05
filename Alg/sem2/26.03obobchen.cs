//obobchen for +-/*
using System;
using System.Linq;

public class AB<T> 
{
  public T a {get; set;}
  public T b {get; set;}

  public AB(T a, T b) {
    this.a = a;
    this.b = b;
  }

  public T Summ() {
    dynamic a1 = a;
    dynamic b1 = b;
    return a1 + b1;
  }

  public T Diff() {
    dynamic a1 = a;
    dynamic b1 = b;
    return a1 - b1;
  }

  public T Prod() {
    dynamic a1 = a;
    dynamic b1 = b;
    return a1 * b1;
  }

  public T Divid() {
    dynamic a1 = a;
    dynamic b1 = b;
    return a1 / b1;
  }
}


class DynamicTypes 
{
  public static void Main(string[] args) 
  {
    AB<int> abints_1 = new AB<int>(4, 8);
    int iSum = abints_1.Summ();
    Console.WriteLine(iSum);

    AB<double> abdouble_1 = new AB<double>(1.89, 9.33);
    double dSum = abdouble_1.Summ();
    Console.WriteLine(dSum);

    AB<int> abints_2 = new AB<int>(4, 8);
    int iDiff = abints_2.Diff();
    Console.WriteLine(iDiff);

    AB<double> abdouble_2 = new AB<double>(1.89, 9.33);
    double dDiff = abdouble_2.Diff();
    Console.WriteLine(dDiff);

    AB<int> abints_3 = new AB<int>(4, 8);
    int iProd = abints_3.Prod();
    Console.WriteLine(iProd);

    AB<double> abdouble_3 = new AB<double>(1.89, 9.33);
    double dProd = abdouble_3.Prod();
    Console.WriteLine(dProd);

    AB<int> abints_4 = new AB<int>(4, 8);
    int iDiv = abints_4.Divid();
    Console.WriteLine(iDiv);

    AB<double> abdouble_4 = new AB<double>(1.89, 9.33);
    double dDiv = abdouble_4.Divid();
    Console.WriteLine(dDiv);
  }
}
