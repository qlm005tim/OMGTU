/*Алгоритмизация

1) Дается три множества, найти пересечения и объединения множеств, используется методы Set'а
Необходимо найти дополнения для каждого множества (тоже методы у Set)

2) На вход подаются данные: номера телефона звонителя, номер звонимого, дата разговора, кол-во минут
а) Определить, на какой номер чаще всего звонил выбранный абонент, сгруппировав данные по датам

б) Определить номера, с которыми наибольшее количество минут разговаривал каждый абонент, сгруппировав данные по дате
через словари удобно будет*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication28
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> set3 = new HashSet<int>();

            Console.WriteLine("Введите элементы первого множества (через пробел):");
            string input1 = Console.ReadLine();
            foreach (var x in input1.Split(' '))
            {
                set1.Add(int.Parse(x));
            }

            Console.WriteLine("Введите элементы второго множества (через пробел):");
            string input2 = Console.ReadLine();
            foreach (var x in input2.Split(' '))
            {
                set2.Add(int.Parse(x));
            }

            Console.WriteLine("Введите элементы третьего множества (через пробел):");
            string input3 = Console.ReadLine();
            foreach (var x in input3.Split(' '))
            {
                set3.Add(int.Parse(x));
            }

            // Находим пересечение всех множеств
            HashSet<int> IntersectionAll = new HashSet<int>(set1);
            IntersectionAll.IntersectWith(set2);
            IntersectionAll.IntersectWith(set3);

            // Находим объединение всех множеств
            HashSet<int> UnionAll = new HashSet<int>(set1);
            UnionAll.UnionWith(set2);
            UnionAll.UnionWith(set3);

            // Находим дополнение для каждого относительно объединения всех множеств
            HashSet<int> Complement1 = new HashSet<int>(UnionAll);
            Complement1.ExceptWith(set1);

            HashSet<int> Complement2 = new HashSet<int>(UnionAll);
            Complement2.ExceptWith(set2);

            HashSet<int> Complement3 = new HashSet<int>(UnionAll);
            Complement3.ExceptWith(set3);

            Console.WriteLine("Пересечение всех множеств: " + string.Join(", ", IntersectionAll));
            Console.WriteLine("Объединение всех множеств: " + string.Join(", ", UnionAll));
            Console.WriteLine("Дополнение для первого множества: " + string.Join(", ", Complement1));
            Console.WriteLine("Дополнение для второго множества: " + string.Join(", ", Complement2));
            Console.WriteLine("Дополнение для третьего множества: " + string.Join(", ", Complement3)); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
class Program
{
    static void Main()
    {
        Dictionary<string, List<string[]>> callsDictionary = new Dictionary<string, List<string[]>>();

        while (true)
        {
            Console.WriteLine("Введите номер телефона звонящего (или 'exit' для выхода):");
            string callerNum = Console.ReadLine();

            if (callerNum == "exit")
            {
                break;
            }

            Console.WriteLine("Введите номер телефона вызываемого абонента:");
            string calleeNum = Console.ReadLine();

            Console.WriteLine("Введите дату звонка:");
            string callDate = Console.ReadLine();

            Console.WriteLine("Введите количество минут разговора:");
            string callTime = Console.ReadLine();

            string[] callDetails = new string[] { calleeNum, callDate, callTime };

            if (callsDictionary.ContainsKey(callerNum))
            {
                callsDictionary[callerNum].Add(callDetails);
            }
            else
            {
                callsDictionary.Add(callerNum, new List<string[]> { callDetails });
            }
        }

        /*Console.WriteLine("Словарь звонков:");
        foreach (var entry in callsDictionary)
        {
            Console.WriteLine($"Номер звонящего: {entry.Key}");
            foreach (var call in entry.Value)
            {
                Console.WriteLine($"\tНомер вызываемого абонента: {call[0]}, Дата звонка: {call[1]}, Длительность разговора: {call[2]} минут");
            }
        }*/




  Console.WriteLine ("input the key ");
   
string key = Console.Readline(); // Выбранный ключ

        int maxCount = 0;
        string startElement = "";
        
        foreach (string[] subArray in callsDictionary[key])
        {
            if (maxCount < CountStartingElements(callsDictionary[key], subArray[0]))
            {
                maxCount = CountStartingElements(callsDictionary[key], subArray[0]);
                startElement = subArray[0];
            }
        }

        List<string[]> newArray = new List<string[]>();
        foreach (string[] subArray in dictionary[key])
        {
            if (subArray[0] == startElement)
            {
                newArray.Add(subArray);
            }
        }

        PrintArray(newArray);
    }
}
}

    static int CountStartingElements(string[][] array, string elem)
    {
        int count = 0;
        foreach (string[] subArray in array)
        {
            if (subArray[0] == elem)
            {
                count++;
            }
        }
        return count;
    }


    static void PrintArray(List<string[]> array)
    {
        foreach (string[] subArr in array)
        {
            Console.WriteLine("[" + string.Join(", ", subArr) + "]");
        }
    }

    
