//Дан массив, состоящий из элементов int типа. Необходимо написать запрос (на LINQ), который выдаёт элементы с последней цифрой кратной 3.
//Дан массив, состоящий из элементов int типа. Необходимо написать запрос (на LINQ), который выдаёт элементы с чётной суммой цифр.
using System;
using System.Linq;

class Program
{
    static int SumDig(int n)
    {
        int s = 0;
        while (n != 0)
        {
            s += n % 10;
            n /= 10;
        }
        return s;
    }

    static void Main()
    {
        int[] arr = {
            123,
            456,
            789,
            111,
            222,
            333,
            444,
            555,
            666,
            777,
            888,
            999,
            23932,
            222233,
        };//examplr

        var last3 = arr.Where(n => (n % 10) % 3 == 0);
        
        var sum2 = arr.Where(n => SumDig(n) % 2 == 0);

        Console.WriteLine("Элементы, у которых последняя цифра кратна 3:");
        foreach (var x in last3)
        {
            Console.WriteLine(x);
        }

        
        Console.WriteLine("Элементы, у которых сумма цифр кратна 2:");
        foreach (var x in sum2)
        {
            Console.WriteLine(x);
        }
    }
}
