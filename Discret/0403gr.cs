using System;

class FloydAlg
{
    static int INF = 9999;

    static void Main()
    {
        int[,] graph = {
            {0, 1, INF, INF, 3},
            {INF, 0, 8, 7, 1},
            {INF, INF, 0, 1, -5},
            {INF, 2, INF, 0, 4},
            {INF, INF, INF, INF, 0}
        };

        int n = graph.GetLength(0);

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, k] + graph[k, j] < graph[i, j])
                    {
                        graph[i, j] = graph[i, k] + graph[k, j];
                    }
                }
            }
        }

        Console.WriteLine("кратчайшие пути между любой парой вершин:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (graph[i, j] == INF)
                {
                    Console.Write("INF ");
                }
                else
                {
                    Console.Write(graph[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}