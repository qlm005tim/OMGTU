using System;
class Program
{
    static void Main()
    {
        double maxd = 0;
        for (int i = 106732567; i <= 152673836; i++)
        {
            double sqr = Math.Sqrt(i);
            double numdel = 0;
            if (Math.Round(sqr) == sqr)
            {
                maxd = 1;
                for (int j = 2; j < Math.Round(sqr); j++)
                {
                    if (i % j == 0)
                    {
                        if (maxd == 1)
                        {
                            maxd = i / j;
                            maxd = Math.Round(maxd);
                        }
                        numdel += 2;
                    }
                    if (numdel == 2) { Console.WriteLine($"{i} \t {maxd} "); }
                }
            }
        }
    }
}
