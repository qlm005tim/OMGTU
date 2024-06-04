//методы array
//методы arraylist
//методы sortedlist
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
    
    static void PrintArray(Array arr)
    {
        // Перебираем все элементы массива и выводим их на экран
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr.GetValue(i));
        }
    }
    
    static void Menu()//menu print
    {
    Console.WriteLine("menu - вывод меню");
    Console.WriteLine("end - выход из программы");
    Console.WriteLine("1 - Count");
    Console.WriteLine("2 - BinSearch");
    Console.WriteLine("3 - Copy (output full)");
    Console.WriteLine("4 - Find");
    Console.WriteLine("5 - FindLast");
    Console.WriteLine("6 - indexOf");
    Console.WriteLine("7 - Reverse");
    Console.WriteLine("8 - Resize");
    Console.WriteLine("9 - Sort");
  }
    
    
    
    static void Main() {
    Console.WriteLine("Операции над Array");
    
    Console.WriteLine("введите количество элементов в массиве ");
    int l=Convert.ToInt32(Console.ReadLine());
    
    Array myArr = Array.CreateInstance(typeof(double), l);//create array double
    
    for (int i=0;i<l;i++)
    {
        Console.WriteLine("input double element ");
        myArr.SetValue(Convert.ToDouble(Console.ReadLine()),i);
    }
    
    
    
    
    Console.WriteLine("Menu");
    Menu();
    
    bool f = true;
    while (f) {
      
      Console.WriteLine("введите команду из меню: ");
      
      string com = Console.ReadLine();

      switch(com) {
        case "menu":
          Menu();
          break;
        case "end":
            {
                f=false;
            }
            break;
        case "1":
            {
                Console.WriteLine("длина массива ");
                int c=myArr.Length;
                Console.WriteLine(c);
            }   
            break;
        case "2":
            {
                Array sArr = (double[])myArr.Clone();
                Array.Sort(sArr);
                Console.WriteLine("отсортированный массив");
                PrintArray(sArr);
                Console.WriteLine("введите число для бинарного поиска ");
                double n=Convert.ToDouble(Console.ReadLine());
                double res=Array.BinarySearch(sArr,n);
                Console.WriteLine("индекс искомого элемента ");
                Console.WriteLine(res);
            }
            break;
        case "3":
        {
            Array nArr=(double[])myArr.Clone();
            Console.WriteLine("копия массива");
            PrintArray(nArr);
        }
        break;
        case "4":{
            Console.WriteLine("поиск первого числа < данного");
            Console.WriteLine("введите число ");
            double n=Convert.ToDouble(Console.ReadLine());
            double res=Array.Find((double[])myArr, x=>x<n);
            Console.WriteLine(res);
        }
        break;
        case "5":
        {
            Console.WriteLine("поиск последнего числа < данного");
            Console.WriteLine("введите число");
            double n=Convert.ToDouble(Console.ReadLine());
            double res=Array.FindLast((double[])myArr, x=>x<n);
            Console.WriteLine(res);
        }
        break;
        case "6":{
            Console.WriteLine("поиск индекса числа");
            Console.WriteLine("введите число");
            double n=Convert.ToDouble(Console.ReadLine());
            double res=Array.IndexOf((double[])myArr, n);
            Console.WriteLine(res);
        }
        break;
        case "7":{
            Array.Reverse((double[])myArr);
            Console.WriteLine("перевернутый массив");
            PrintArray(myArr);
        }
        break;
        case "8":{
            Console.WriteLine("новая длина");
            int nl=Convert.ToInt32(Console.ReadLine());
            //Array.Resize(ref myArr, nl);
            PrintArray(myArr);
            
        }
        break;
        case "9":{
            Array.Sort(myArr);
            Console.WriteLine("отсортированный массив");
            PrintArray(myArr);
        }
        break;
        default:{
            Console.WriteLine("нет такого действия");
        }
        break;
    }
    }
    }
}


