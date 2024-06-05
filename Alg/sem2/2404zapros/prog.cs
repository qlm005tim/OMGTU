//Дан входной файл из символов (латинские буквы) необходимо опредилить символ, который встречается чаще всего, кол-во уникальных символов, выдать список символов, с помощью которых составлена последовательность в файле (в алф порядке)
//Ограничения: данные считывать в массивы, списки и др. элементы коллекций (нельзя для хранения исходных данных, для обработки можно)
//Строк может быть несколько, в строку считывать можно
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string fPath = "inp.txt";
        
        string f = File.ReadAllText(fPath);//read file in one string
        
        int[] countsOfsyms = new int[26];//kolvo vsex v alf in f
        
        int maxCount = 0;// count of most usable symb
        
        char mostusChar = '\0';//most usable symbol
        
        HashSet<char> uniqueChars = new HashSet<char>();//set with unik chars

        foreach (char c in f)
        {
            if (char.IsLetter(c))
            {
                int index = char.ToLower(c) - 'a';
                
                countsOfsyms[index]++;//count of letter
                uniqueChars.Add(c);//set of all symbols of alf in f

                if (countsOfsyms[index] > maxCount)
                {
                    maxCount = countsOfsyms[index];
                    mostusChar = c;
                }
            }
        }

        Console.WriteLine($"Символ, встречающийся чаще всего: {mostusChar} ({maxCount} раз)");
        Console.WriteLine($"Количество уникальных символов: {uniqueChars.Count}");
        Console.WriteLine($"Список символов (в алфавитном порядке): {string.Join(" ", uniqueChars.OrderBy(c => c))}");
    }
}
