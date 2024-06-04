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


using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
    
    static void PrintArrayList(ArrayList arrlist)
    {
        
        foreach (double x in arrlist)
        {
            Console.WriteLine(x);
        }
    }
    
    static void Menu()//menu print
    {
    Console.WriteLine("menu - вывод меню");
    Console.WriteLine("end - выход из программы");
    Console.WriteLine("1 - Count");
    Console.WriteLine("2 - BinSearch");
    Console.WriteLine("3 - Copy (output full)");
    Console.WriteLine("4 - indexOf");
    Console.WriteLine("5 - Insert");
    Console.WriteLine("6 - Reverse");
    Console.WriteLine("7 - Sort");
    Console.WriteLine("8 -Add");
  }
    

    static void Main() {
    Console.WriteLine("Операции над ArrayList");
    
    ArrayList myAL=new ArrayList();
    Console.WriteLine("введите элемент в ArrayList, ! для завершения ввода");
    
    bool i=true;
    while(i){
        
        string n = Console.ReadLine();
        if (n=="!"){
            i=false;
            break;
        }
        double num=Convert.ToDouble(n);
        myAL.Add(num);
        
    }
    
    //PrintArrayList(myAL);
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
                int c=myAL.Count;
                Console.WriteLine(c);
            }   
            break;
        case "2":
            {
                var newAL = new ArrayList(myAL);
                Console.WriteLine("отсортированный ArrayList:");
                newAL.Sort();
                PrintArrayList(newAL);

                Console.WriteLine("введите число для бинарного поиска :");
                double number = Convert.ToDouble(Console.ReadLine());
                double res = newAL.BinarySearch(number);

                Console.WriteLine("Индекс искомого числа:");
                Console.WriteLine(res);
                
            }
            break;
        case "3":
        {
            var newAL=new ArrayList(myAL);
            Console.WriteLine("копия ");
            PrintArrayList(newAL);
        }
        break;
        case "4":{
            Console.WriteLine("поиск Индекса данного числа ");
            Console.WriteLine("введите число ");
            double n=Convert.ToDouble(Console.ReadLine());
            double res=myAL.IndexOf(n);
            Console.WriteLine("индекс");
            Console.WriteLine(res);
        }
        break;
        case "5":
        {
            Console.WriteLine("вчтавить число");
            Console.WriteLine("введите ind");
            int ind=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите число");
            double n=Convert.ToDouble(Console.ReadLine());
            myAL.Insert(ind,n);
            
            Console.WriteLine("с числом");
            PrintArrayList(myAL);
        }
        break;
        case "6":{
            Console.WriteLine("перевернутый");
            myAL.Reverse();
            PrintArrayList(myAL);
        }
        break;
        case "7":{
            Console.WriteLine("отсортированный");
            myAL.Sort();
            PrintArrayList(myAL);
        }
        break;
        case "8":{
            Console.WriteLine("введите число для добавления");
            double n=Convert.ToDouble(Console.ReadLine());
            myAL.Add(n);
            
            PrintArrayList(myAL);
            
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

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
    
    static void PrintSortedList(SortedList slist)
    {
        
        for (int i=0;i<slist.Count;i++)
        {
            Console.WriteLine("Key: {0},\tValue: {1}", slist.GetKey(i), slist.GetByIndex(i));
        }
    }
    
    static void Menu()//menu print
    {
    Console.WriteLine("menu - вывод меню");
    Console.WriteLine("end - выход из программы");
    Console.WriteLine("1 - Add");
    Console.WriteLine("2 - indexOfKey");
    Console.WriteLine("3 - indexOfValue");
    
  }
    

    static void Main() {
    Console.WriteLine("Операции над ArrayList");
    
    SortedList mySL=new SortedList();
    Console.WriteLine("Введите количество пар ключ-значение:");
    int l = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i < l; i++){
        Console.WriteLine("введите key val");
        double key = Convert.ToDouble(Console.ReadLine());
        double value = Convert.ToDouble(Console.ReadLine());
        mySL.Add(key,value);
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
                Console.WriteLine("введите key val ");
                double key = Convert.ToDouble(Console.ReadLine());
                double value = Convert.ToDouble(Console.ReadLine());
                mySL.Add(key,value);
                Console.WriteLine("add");
                PrintSortedList(mySL);
            }   
            break;
        case "2":
            {
                Console.WriteLine("Введите ключ:");
            double key = Convert.ToDouble(Console.ReadLine());
            int index = mySL.IndexOfKey(key);
            Console.WriteLine("Индекс ключа:");
            Console.WriteLine(index);

            }
            break;
        case "3":
        {
            Console.WriteLine("Введите значение:");
            double value = Convert.ToDouble(Console.ReadLine());
            int index = mySL.IndexOfValue(value);
            Console.WriteLine("Индекс значения:");
            Console.WriteLine(index);
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
