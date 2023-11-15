using System;
class Program
{
    static int[,] CreateArray(int m, int n)//функция для создания массива
    {
        int[,] array = new int[m, n];
        Console.WriteLine($"Введитe элементы массива {m}*{n}:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"злемент [{i + 1}, {j + 1}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return array;
    }

    static int[] FindMaxNegElements(int[,] array)//функция поиска максимального отриц
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[] maxNegElements = new int[rows];

        for (int i = 0; i < rows; i++)
        {

            int maxNeg = int.MinValue;
            bool foundNeg = false;

            for (int j = 0; j < cols; j++)
            {

                if (array[i, j] < 0 && array[i, j] > maxNeg)
                {
                    maxNeg = array[i, j];
                    foundNeg = true;
                }
            }
            if (foundNeg)
            {
                maxNegElements[i] = maxNeg;
            }
            else
            {
                
                maxNegElements[i] = 0;
            }
        }
        return maxNegElements;
    }

    static int[] CountDifElements(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int minElement = int.MaxValue;
        for (int i = 0; i < rows; i++)
        {

            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] < minElement)
                {
                    minElement = array[i, j];
                }
            }
        }
        
        int[] res = new int[cols * 2];
        for (int j = 0; j < cols; j++)
        {
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                if (array[i, j] != minElement)
                {
                    count++;
                }
            }
             
            res[j * 2] = j + 1;
            res[j * 2 + 1] = count;
        }
        return res;
    }

    static int[,] ReplaceRow(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int maxEvenSum = 0;

        for (int i = 0; i < rows; i++)
        {
            int rowEvenSum = 0;
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] % 2 == 0)
                {
                    rowEvenSum += array[i, j];
                }
            }

            if (rowEvenSum > maxEvenSum)
            {
                maxEvenSum = rowEvenSum;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            int rowEvenSum = 0;
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] % 2 == 0)
                {
                    rowEvenSum += array[i, j];
                }
            }
            if (rowEvenSum == maxEvenSum)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = 1;
                }
            }
        }
        return array;
    }


    static void Main()
    {
        Console.WriteLine("Введите количество строк (М):");//ввод размерности
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов (N):");
        int n = int.Parse(Console.ReadLine());

        int[,] array = CreateArray(m, n);//создание двумерного массива

        int[] maxNegElements = FindMaxNegElements(array);//вызов функции
        Console.WriteLine("Максимальные отрицательные элементы в каждой строке:");
        for (int i = 0; i < maxNegElements.Length; i++)
        {
            if (maxNegElements[i]!=0)
            {
                Console.WriteLine($"str {i + 1}: {maxNegElements[i]}");
            }
            else
            {
                Console.WriteLine($"str {i + 1}: нет отрицательных");
            }
        }
            
        int[] result = CountDifElements(array);//вызов функции
        Console.WriteLine("Столбец\tКоличество отличных элементов");

        for (int i = 0; i < result.Length; i += 2)
        {
            Console.WriteLine($"{result[i]}\t{result[i + 1]}");
        }

        int[,] newArray = ReplaceRow(array);//вызов функции
        Console.WriteLine("Измененный массив:");
        for (int i = 0; i < newArray.GetLength(0); i++)
        {
            for (int j = 0; j < newArray.GetLength(1); j++)
            {
                Console.Write(newArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
