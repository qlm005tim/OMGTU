using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using System.IO;
using System.Collections;
namespace array
{
    public class Menu
    {
        public static int Show_Menu()
        {
            Console.WriteLine("1) Создать лист");
            Console.WriteLine("2) Добавить элемент");
            Console.WriteLine("3) Изменить элемент");           
            Console.WriteLine("4) Удалить элемент");            
            Console.WriteLine("5) Подсчитать колво элемента"); 
            Console.WriteLine("6) Бинарный поиск элемента");    
            Console.WriteLine("7) Копировать элементы");        
            Console.WriteLine("8) Поиск индекса элемента");     
            Console.WriteLine("9) Вставить элемент");           
            Console.WriteLine("10) Развернуть порядок");        
            Console.WriteLine("11) Сортировать элементы");      
            Console.WriteLine("12) Вывести лист");
            Console.WriteLine("13) Выйти из программы");
            Console.Write("\n Введите число");
            int res = Convert.ToInt32(Console.ReadLine());
            return res;
        }
    }
    internal class Program
    {
        public static void Main()
        {
            int i = 0;
            ArrayList Collection = new ArrayList();
            while (true)
            {
                switch (Menu.Show_Menu())
                {
                    case 1:
                        Collection = new ArrayList();
                        Console.Write("Введите колво элементов:");
                        i = Convert.ToInt32(Console.ReadLine());
                        for (int j = 0; j < i; j++) {Collection.Add(Console.ReadLine()); }
                        break;
                    case 2:
                        Console.Write("Введите элемент для добавления:");
                        Collection.Add(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Введите номер элемента для замены: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите новый элемент: ");
                        Collection[i] = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Введите индекс элемента который нужно удалить: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Collection.Remove(i);
                        break;
                    case 5:
                        i = Collection.Count;
                        Console.WriteLine($"Количество элементов в листе: {i}");
                        break;
                    case 6:
                        Collection.Sort();
                        Console.Write("Введите элемент который нужно найти: ");
                        var r = Console.ReadLine();
                        Collection.BinarySearch(r);
                        break;
                    case 7:
                        Console.Write("Введите индекс, с которого нужно скопировать элементы: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите с индекс, по который нужно скопировать элементы: ");
                        int e = Convert.ToInt32(Console.ReadLine());
                        int[] CopyArray = new int[e - i];
                        Collection.CopyTo(i, CopyArray, 0, e - i);
                        break;
                    case 8:
                        Console.Write("Введите элемент индекс которого необходимо найти: ");
                        r = Console.ReadLine();
                        Console.WriteLine($"Индекс элемента {r}: {Collection.IndexOf(r)}");
                        break;
                    case 9:
                        Console.Write("Введите элемент который нужно вставить: ");
                        r = Console.ReadLine();
                        Console.WriteLine("Введите индекс нового элемента: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Collection.Insert(i, r);
                        break;
                    case 10:
                        Collection.Reverse();
                        break;
                    case 11:
                        Collection.Sort();
                        break;
                    case 12:
                        foreach (var item in Collection) { Console.WriteLine(item); }
                        break;
                    case 13:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
