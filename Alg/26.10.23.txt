// Задано множество из N элементов
// Необходимо сформировать одномерные массивы, которые хранят:
// 1. Пересечение всех множеств
// 2. Объединение всех множеств
// 3. Дополнение для каждого множества относительно объединения
using System;
using System.Linq;

class Program_with_sets {
    public static int[] sort(int[] array) {
        int[] sorted_array = new int[array.Length];
        for (int i = 0; i < array.Length; i++) {
            int min = Int32.MaxValue;
            for (int j = i; j < array.Length; j++) {
                if (array[j] < min) {
                    min = array[j];
                    int c = array[i];
                    array[i] = array[j];
                    array[j] = c;
                }
            }
            sorted_array[i] = min;
        }
        return sorted_array;
    }

    public static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] sets = new int [n][];
        int length = 0;

        for (int i = 0; i < n; i++) {
            int m = Convert.ToInt32(Console.ReadLine());
            length += m;
            sets[i] = new int[m];
            for (int j = 0; j < m; j++) {
                sets[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int[] union = new int[length];
        int countUnion = 0;
        Console.WriteLine("Множества:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < sets[i].Length; j++) {
                Console.Write($"{sets[i][j].ToString().PadLeft(5, ' ')} ");
                if (!union.Contains(sets[i][j])) {
                    union[countUnion] = sets[i][j];
                    countUnion++;
                }
            }
            Console.WriteLine();
        }

        union = new int[countUnion];
        int pointer = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < sets[i].Length; j++) {
                if (!union.Contains(sets[i][j])) {
                    union[pointer] = sets[i][j];
                    pointer++;
                }
            }
        }

        union = sort(union);

        int[] intersections = new int[union.Length];
        int countIntersection = 0;
        for (int i = 0; i < intersections.Length; i++) {
            intersections[i] = 0;
        }

        for (int k = 0; k < union.Length; k++) {
            for (int i = 0; i < n; i++) {
                if (sets[i].Contains(union[k])) {
                    intersections[k]++;
                }
            }
        }

        for (int i = 0; i < intersections.Length; i++) {
            if (intersections[i] == n) {
                countIntersection++;
            }
        }

        int[] intersection = new int[countIntersection];
        pointer = 0;
        for (int i = 0; i < intersections.Length; i++) {
            if (intersections[i] == n) {
                intersection[pointer] = union[i];
                pointer++;
            }
        }

        Console.WriteLine("Пересечение всех множеств:");
        if (countIntersection > 0) {
            foreach (int item in intersection) {
                Console.Write($"{item} ");
            }
        } else {
            Console.Write("Пусто!");
        }
        Console.WriteLine();

        Console.WriteLine("Объединение всех множеств:");
        if (countUnion > 0) {
            foreach (int item in union) {
                Console.Write($"{item} ");
            }
        } else {
            Console.Write("Пусто!");
        }
        Console.WriteLine();

        Console.WriteLine("Дополнение для каждого множества относительно объединения:");
        for (int i = 0; i < n; i++) {
            int f = 0;
            Console.Write($"{i}:\t");
            for (int k = 0; k < union.Length; k++) {
                if (!sets[i].Contains(union[k])) {
                    Console.Write("{0} ", union[k]);
                    f = 1;
                }
            }
            if (f == 0) {
                Console.Write("Пусто!");
            }
            Console.WriteLine();
       }
    }
}
