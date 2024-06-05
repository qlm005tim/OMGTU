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
    static int GetMinCount_L(string line)//минимальная длина подстроки а в строке
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
                if (count > 0 && count < min_count)
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
            int min_len_f = int.MaxValue;//минимальная длина подстроки а во всем файле
            
            string min_str_f = "";// str with min 'a' substring по всему файлу

            string line;
            int min_count_f = int.MaxValue;//минимальная длина подстроки а по всему файлу
            
            while ((line = f.ReadLine()) != null)//чтение строки файла
            {
                int count = GetMinCount_L(line);//минимальная длина подстроки а по отдельной строке

                if (count > 0 && count < min_count_f)
                {
                    min_count_f = count;//
                }

                if (min_count_f > 0 && min_count_f < min_len_f)// 
                {
                    min_len_f = min_count_f;// мин длина подстроки а в файле и строка из файла с ней обновляется
                    min_str_f = line;
                }
            }
            
            Console.WriteLine(min_str_f);
        }
    }
}
