zapr // Дан массив размерностью н на м
1 опред колво столбцов в котор сумма элементов отриц, а произв положительно
2 опред, во всех ли строках мин элемент четный 
3 посчитать колво ненул элем в массиве о
4 определить в каждом столбце наиб четный элемент
5 определить колво пар строк состоящих из одинаковых элементов
[[1,1,1]
[1,1,1]
[1,1,1]]-три пары
[[1,1,0]
[1,0,1]
[0,0,1]]-одна пара порядок не важен
сумма произв колво  нулей одинаковое

using System;
class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        
        int[,] array = new int[n, m];
        
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        
        int countCols = 0;
        for (int j = 0; j < m; j++)
        {
            int sum = 0;
            int product = 1;
            for (int i = 0; i < n; i++)
            {
                sum += array[i, j];
                product *= array[i, j];
            }
            if (sum < 0 && product > 0)
            {
                countCols++;
            }
        }
        Console.WriteLine($"Количество столбцов, в которых сумма отрицательна, произведение положительно: {countCols}");

        bool allMinEven = true;
        for (int i = 0; i < n; i++)
        {
            int minEl = array[i, 0];
            for (int j = 1; j < m; j++)
            {
                if (array[i, j] < minEl)
                {
                    minEl = array[i, j];
                }
            }
            if (minEl % 2 != 0)
            {
                allMinEven = false;
                break;
            }
        }
        if (allMinEven)
        {
            Console.WriteLine("Во всех строках минимальный элемент чётный.");
        }
        else
        {
            Console.WriteLine("Не во всех строках минимальный элемент чётный.");
        }

        int noZero = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] != 0)
                {
                    noZero++;
                }
            }
        }
        Console.WriteLine($"Количество ненулевых элементов в массиве: {noZero}");

        for (int j = 0; j < m; j++)
        {
            int maxEven = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (array[i, j] % 2 == 0 && array[i, j] > maxEven)
                {
                    maxEven = array[i, j];
                }
            }
            if (maxEven != int.MinValue)
            {
                Console.WriteLine($"Наибольший четный элемент в столбце {j + 1}: {maxEven}");
            }
            else
            {
                Console.WriteLine($"В столбце {j + 1} нет четных элементов.");
            }
        }

        int count = CountPairs(array);
        Console.WriteLine($"Количество пар строк с одинаковыми элементами: {count}");

    }

    static int CountPairs(int[,] array)
    {
        int rows = array.GetLength(0);
        int count = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < rows; j++)
            {
                if (CheckConditions(array, i, j))
                {
                    count++;
                }
            }
        }
        return count;
    }

    static bool CheckConditions(int[,] array, int row1, int row2)
    {
        int cols = array.GetLength(1);

        int sum1 = 0, sum2 = 0;
        int product1 = 1, product2 = 1;
        int zeroCount1 = 0, zeroCount2 = 0;

        for (int j = 0; j < cols; j++)
        {
            sum1 += array[row1, j];
            sum2 += array[row2, j];
            product1 *= array[row1, j];
            product2 *= array[row2, j];
            if (array[row1, j] == 0)
            {
                zeroCount1++;
            }
            if (array[row2, j] == 0)
            {
                zeroCount2++;
            }
        }
       
        return sum1 == sum2 && product1 == product2 && zeroCount1 == zeroCount2;
    }
}
