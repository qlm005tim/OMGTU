using System;

class Program
{
    static int[,] CreateArray(int m, int n)//функция для создания массива
    {
        int[,] array = new int[m, n];

        Console.WriteLine($"Введитe лементы массива {m}*{n}:");

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

    static int[] FindMaxNegativeElements(int[,] array)//функция поиска максимального отриц
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[] maxNegativeElements = new int[rows];

        for (int i = 0; i < rows; i++)
        {

            int maxNegative = int.MinValue;
            bool foundNegative = false;

            for (int j = 0; j < cols; j++)
            {

                if (array[i, j] < 0 && array[i, j] > maxNegative)
                {
                    maxNegative = array[i, j];
                    foundNegative = true;
                }
            }
            if (foundNegative)
            {
                maxNegativeElements[i] = maxNegative;
            }
            else
            {
                // Если нет отрицательных элементов в строке, устанавливаем значение в maxNegativeElements[i] = 0
                maxNegativeElements[i] = 0;
            }
        }
        return maxNegativeElements;
    }

    static int[] CountDifferentElements(int[,] array)
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
        // Считаем количество отличных элементов в каждом столбце
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
            // Записываем номер столбца и количество отличных элементов в результат 
            res[j * 2] = j + 1;
            res[j * 2 + 1] = count;
        }
        return res;
    }

    /*static int[][] ReplaceRowWithMaxEvenSum(int[][] matrix)

    if (matrix == null || matrix. Length == 0 || matrix[0].Length == 0)

{

// Обработка некорректных входных данных, например, пустой или нулевой массив return matrix;

}

int maxEvenSum int.MinValue; =

int rowIndex = - 1 ;

// Находим индекс строки с наибольшей суммой четных элементов for (int i = 0 i < matrix. Length; i++) {

int evenSum = 0

for (int j = 0 j < matrix[i].Length; j++)

{

if (matrix[i][j] % 2 ==0

{

evenSum += matrix[i][j];

}

}

if (evenSum > maxEvenSum)
maxEvenSum = evenSum;

rowIndex = i ,

}

}

if (rowIndex l = - 1 )

f

// Заменяем все элементы найденной строки на единицы for (int j = 0 j < matrix[rowIndex].Length; j++)

matrix[rowIndex I[j] = 1

}

}

return matrix;

}

static void PrintMatrix(int[][] matrix)

{ foreach (var row in matrix) foreach (var element in row) { } Console.Write(element + " "); Console.WriteLine(); } \ ^ */

    static void Main()
    {
        Console.WriteLine("Введите количество строк (М):");//ввод размерности
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов (N):");
        int n = int.Parse(Console.ReadLine());

        int[,] array = CreateArray(m, n);//создание двумерного массива

        int[] maxNegativeElements = FindMaxNegativeElements(array);//вызов функции
        Console.WriteLine("Максимальные отрицательные элементы в каждой строке:");
        for (int i = 0; i < maxNegativeElements.Length; i++)
        {
            if (maxNegativeElements[i]!=0)
            {
                Console.WriteLine($"str {i + 1}: {maxNegativeElements[i]}");
            }
            else
            {
                Console.WriteLine($"str {i + 1}: нет отрицательных");
            }
        }
            
        int[] result = CountDifferentElements(array);//вызов функции
        Console.WriteLine("Столбец\tКоличество отличных элементов");

        for (int i = 0; i < result.Length; i += 2)
        {
            Console.WriteLine($"{result[i]}\t{result[i + 1]}");
        }

        /*matrix = ReplaceRowWithMaxEvenSum(array);

        Console.WriteLine("Mampuua после замены: "); PrintMatrix(matrix);*/

    }

}
