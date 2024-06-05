структуры и файлы
Задачка по алгоритмизации на структуры и файлы. 
В файле хранятся данные следующей структуры:
-год рождения
-город рождения
-страна рождения
Задание: необходимо создать 3 выходных файла. 
*1 файл: данные сгруппированы по году рождения (без разницы, по возрастанию или убыванию), 
*2 файл: сгруппировать по городам
*3 файл: вывести данные тех, кто родился в определенной стране. Страна запрашивается пользователем.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program {
    
  public static int CompareDates(string s1, string s2) 
  {
    double date1 = Convert.ToDouble(s1.Split()[0]);//s1-year1 city1 country1
    double date2 = Convert.ToDouble(s2.Split()[0]);
    
    if (date1 > date2) 
    {
      return 1;
    } 
    else 
    {
      return -1;
    }
  }

  public static void Main(string[] args) {
    
    List<string> f = File.ReadAllLines("./country.txt").ToList();//read file in list with strs 'year city country'
    
    List<string> f_sortyears = new List<string>(f);//list with sort years copy for sort
    
    f_sortyears.Sort(CompareDates);//sort copied list
    
    
    List<string> f_sortcity = new List<string>(f);//copy for sort by cities
    
    f_sortcity.Sort((s1, s2) => s1.Split()[1].CompareTo(s2.Split()[1]));//sort copied list


    Console.WriteLine("Отсортировано по дате: ");
    
    using (StreamWriter sw = File.CreateText("./outfile1.txt")) 
    {
      foreach (var line in f_sortyears)
      {
        Console.WriteLine(line);
        sw.WriteLine(line);
      }
    }


    Console.WriteLine("Отсортировано по городам:");
    using (StreamWriter sw = File.CreateText("./outfile2.txt"))  
    {
      foreach (var line in f_sortcity) 
      {
        string[] split_line = line.Split();
        Console.WriteLine($"{split_line[1]} {split_line[0]} {split_line[2]}");
        sw.WriteLine($"{split_line[1]} {split_line[0]} {split_line[2]}");
      }
    }

    Console.WriteLine("Введите название страны:");
    string country = Console.ReadLine();
    using (StreamWriter sw = File.CreateText("./outfile3.txt"))  
    {
      foreach (var line in f) 
      {
        if (country == line.Split()[2]) 
        {
          Console.WriteLine(line);
          sw.WriteLine(line);
        }
      }
    }

  }
}
