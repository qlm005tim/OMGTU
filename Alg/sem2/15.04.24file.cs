//даны два файла с отсортированными данными необходимо сформировать выходной файл, который является слиянием двух файлов, 
//данные в выходном файле тоже должны быть отсортированы, ограничения: нельзя считывать данные в промежуточные списки -> надо брать попеременно.

//дан входной файл состоящий из строк необходимо вывести строку с наименьшей длиной подпоследовательности состоящей из символов а
using System;
using System.IO;

class FileMerge
{
    static void Main()
    {
        // Open input and output files
        using (StreamReader f1 = new StreamReader("inp1.txt"))//obj of files f1 and f2
        using (StreamReader f2 = new StreamReader("inp2.txt"))
        using (StreamWriter f_out = new StreamWriter("output.txt"))
        {
            
            string srt1 = f1.ReadLine();//str from f1
            string str2 = f2.ReadLine();//str from f2

            // Merge files  брать строки из файлов в алф порядке записывать в выходной файл
            while (srt1 != null && str2 != null)
            {
                if (string.Compare(str1, str2) < 0)
                {
                    f_out.WriteLine(str1);
                    str1 = f1.ReadLine();
                }
                else
                {
                    f_out.WriteLine(str2);
                    str2 = f2.ReadLine();
                }
            }

            while (str1 != null)
            {
                f_out.WriteLine(str1);
                str1 = f1.ReadLine();
            }

            while (str2 != null)
            {
                f_out.WriteLine(str2);
                str2 = f2.ReadLine();
            }
        }
    }
}


using System;
using System.IO;
using System.Linq;

class Program
{
    static int GetMinCount(string line)//min len 'a' substring
    {
        int count = 0;
        int min_count = int.MaxValue;
        
        foreach (char c in line)
        {
            if (c == 'а')
            {
                count++;
            }
            
            else
            {
                if (count > 0 && count < min_count)//obnov min count
                {
                    min_count = count;
                }
                count = 0;
            }
        }
        return min_count;
    }

    static void Main()
    {
        using (StreamReader f = new StreamReader("input.txt"))//fail
        {
            int min_len = int.MaxValue;//min len substring with a
            string min_str = "";// str with min 'a' substring

            string line;
            int min_count = int.MaxValue;
            
            while ((line = f.ReadLine()) != null)
            {
                int count = GetMinCount(line);

                if (count > 0 && count < min_count)
                {
                    min_count = count;
                }

                if (min_count > 0 && min_count < min_len)
                {
                    min_len = min_count;
                    min_str = line;
                }
            }
            Console.WriteLine(min_str);
        }
    }
}
