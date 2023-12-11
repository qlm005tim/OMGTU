
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите скорость u (дробное число):");
        double u = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите количество пунктов n:");
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

        double v = u / 60;// скорость в км/мин
        double tost0 = (hz - hv) * 60 + (60 - mv) + mz;// остаток времени в начале дня(продолжительность дня) 

        double[] rast = new double[n + 1];// массив с расстояниями
        rast[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            rast[i] = numbers[i - 1];
        }

        string numost = "";// номера остановок
        int count_days = 0;// количество дней
        double tost_pre = tost0;// остаток времени после дохождения до предыдущего пункта
        for (int i = 1; i <= n; i++)
        {

            double t = (rast[i] - rast[i - 1]) / v;// время пути до пункта
            double tost = tost_pre - t;// остаток времени до ночи после прихода в пункт


            if (tost < 0)// если остаток отрицательный, то нужно остаться в предыдущем пункте и продолжить путь с нового дня
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