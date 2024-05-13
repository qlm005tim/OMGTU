using System;
using System.Linq;

class TrapezoidalRule
{
    static void Main()
    {
        Func<double, double> f = (double x) => -x * x + 9;
        var answ = TrapezoidalRule.Solve(f, -3, 3, 0.1);
        Console.WriteLine(answ); //answer

        Console.WriteLine(f(2.9)); //it is function no answer
    }

    public static double Solve(Func<double, double> f, double a, double b, double dx)
    {
        double eps = 1E-7;
        if ((Math.Abs(b - a) >= -eps || dx <= eps || (a + b + dx) % 1 != 0))
        {
            throw new ArgumentException("Неверные данные");
        }

        double s_trap = Enumerable.Range(0, (int)((b - a) / dx))
            .Select(i => (f(a + i * dx) + f(a + (i + 1) * dx)) * 0.5 * dx)
            .Sum();

        return s_trap;
    }
}
```
В этом примере мы используем LINQ для замены цикла `for` и вычисления суммы трапеций. Мы генерируем последовательность чисел от 0 до количества интервалов, используя `Enumerable.Range`, затем вычисляем площадь каждой трапеции с помощью `Select`, и, наконец, суммируем все площади с помощью `Sum`.