
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите скорость u (дробное число):");
        double u = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите количество чисел n:");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] numbers = new double[n];
        Console.WriteLine("Введите {0} чисел через пробел:", n);
        string[] inputNumbers = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            numbers[i] = Convert.ToDouble(inputNumbers[i]);
        }

        Console.WriteLine("Введите часы восхода hv:");
        int hv = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите минуты восхода mv:");
        int mv = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите часы заката hz:");
        int hz = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите минуты заката mz:");
        int mz = Convert.ToInt32(Console.ReadLine());

        double v = u / 60;
        double tost0 = (hz - hv) * 60 + (60 - mv) + mz;

        double[] rast = new double[n + 1];
        rast[0] = 0;
        Array.Copy(numbers, 0, rast, 1, n);

        string numost = "";
        int count_days = 0;
        double tost_pre = tost0;
        for (int i = 1; i <= n; i++)
        {
             
            double t = (rast[i] - rast[i - 1]) / v;
            double tost = tost_pre - t;
   

            if (tost < 0)
            {
                
                tost = tost0 - t;
                tost_pre=tost;
                numost += (i - 1).ToString() + " ";
                count_days++;
            }
            else
            {
                tost_pre=tost;
            }
        }

        Console.WriteLine("numost: " + numost);
        Console.WriteLine("count_days: " + (count_days + 1));

        Console.ReadLine();
    }
}
