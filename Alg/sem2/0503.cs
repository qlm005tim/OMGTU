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
        Dictionary<string, List<string[]>> callsDictionary = new Dictionary<string, List<string[]>>();//создание словаря
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

string key = Console.ReadLine(); // Выбранный ключ

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

List<string[]> res = new List<string[]>();
        foreach (string[] subArray in callsDictionary[key])
        {
            if (subArray[0] == startElement)
            {
                res.Add(subArray);
            }
        }

        List<string[]> result = ResList(res);
        PrintArray(result);//кому чаще всего звонил выбранный


foreach(var entry in callsDictionary) {

        var result1 = DictFunc(callsDictionary, entry.Key);

Console.WriteLine(entry.Key);

        PrintArray(ResList(result1));//с кем дольше всего говорил по сумме времени

    }
}



static List<string[]> ResList(List<string[]> res)//функция группировки по дате
    {
        HashSet<string> setElements = new HashSet<string>();
        List<string[]> result = new List<string[]>();

        foreach (var arr in res)
        {
            setElements.Add(arr[1]);
        }

        foreach (var element in setElements)
        {
            foreach (var arr in res)
            {
                if (arr[1] == element)
                {
                    result.Add(arr);
                }
            }
        }

        return result;
    }

    static int CountStartingElements(List<string[]> array, string elem)//функция для подсчёта сколько раз содержися определённый вызываемый абонент в массиве значений
    {
        int count = 0;
        foreach (string[] subArr in array)
        {
            if (subArr[0] == elem)
            {
                count++;
            }
        }
        return count;
    }

    static void PrintArray(List<string[]> array)//функция для печати результата со скобками
    {
        foreach (string[] subArr in array)
        {
            Console.WriteLine("[" + string.Join(", ", subArr) + "]");
        }
    }


    public static List<string[]> DictFunc(Dictionary<string, List<string[]>> callsDictionary, string key)//функция для вывода информации о вызываемом абоненте с максимальной суммой времени
    {
        var setA = new HashSet<string>();
        var res = new List<string[]>();
        var maxSum = int.MinValue;

        foreach (var sublist in callsDictionary[key])
        {
            setA.Add(sublist[0]);
        }
foreach (var item in setA)
        {
            var sum = 0;
            foreach (var sublist in callsDictionary[key])
           {
                if (sublist[0] == item)
                {
                    sum += int.Parse(sublist[2]);
                }
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                res.Clear();
                foreach (var sublist in callsDictionary[key])
                {
                    if (sublist[0] == item)
                    {
                        res.Add(sublist);
                    }
                }
            }
        }

        return res;
    }
}
