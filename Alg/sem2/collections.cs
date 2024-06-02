методы array
методы arraylist
методы sortedlist
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
    
    static void PrintArrayElements(Array arr)
    {
        // Перебираем все элементы массива и выводим их на экран
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr.GetValue(i));
        }
    }
    
    static void Main() {
    Console.WriteLine("Операции над Array");
    
    Console.WriteLine("введите количество элементов в массиве");
    int l=Convert.ToInt32(Console.ReadLine());
    
    Array myArr = Array.CreateInstance(typeof(double), l);
    
    for (int i=0;i<l;i++){
        Console.WriteLine("inp element");
        myArr.SetValue(Convert.ToDouble(Console.ReadLine()),i);
    }
    
    /*Console.WriteLine("Введите элементы Array:");
    double[] array = Console.ReadLine()
      .Split(" ")
      .Select(s => Convert.ToDouble(s))
      .ToArray();

    Console.WriteLine();
    DisplayHelp();
    Console.WriteLine();

    bool running = true;
    while (running) {
      Console.WriteLine();
      Console.WriteLine("Array:");
      DisplayArray(array);
      Console.WriteLine();
      string command = Console.ReadLine();

      switch(command) {
        case "?":
          DisplayHelp();
          break;
        case "!":
        
        
}
}*/

        PrintArrayElements(myArr);
    }
}
