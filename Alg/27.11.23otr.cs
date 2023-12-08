//трасса
//начальная точка и финиш 
//имеются дороги, которые соединяют верхнийпуть с нижним. определить самый короткий путь. без списков и массивов. 
//n - количество интервалов. 
//t - длина схода
//a1 b1 n штук
//a2 b2
using System;
    class Program
    {
        static void Main(string[] args)
        {
            int t;
            int n;
            int x = 0;
            Console.WriteLine("t");
           t=Convert.ToInt32(Console.ReadLine());
            int y = t;
            Console.WriteLine("n");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"a{i+1}, b{i+1}");
                string ab = Console.ReadLine();
                int a = Convert.ToInt32(ab.Split(' ')[0]);
                int b = Convert.ToInt32(ab.Split(' ')[1]);
                x = x + a;
                y = Math.Min(x+t, y+b);
            }
            Console.WriteLine(Math.Min(x+t,y));
            Console.ReadLine();

        }
    }
}