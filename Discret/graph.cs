using System;
using System.Collections.Generic;

public class PrimsAlgorithm
{
    public static int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;
        
        for (int i = 0; i < distances.Length; i++)
        {
            if (!visited[i] && distances[i] < min)
            {
                min = distances[i];
                minIndex = i;
            }
        }
        
        return minIndex;
    }
    
    public static void PrimsMST(int[,] graph, int vertices)
    {
        int[] parent = new int[vertices];
        int[] distances = new int[vertices];
        bool[] visited = new bool[vertices];
        
        for (int i = 0; i < vertices; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }
        
        distances[0] = 0;
        parent[0] = -1;
        
        for (int count = 0; count < vertices - 1; count++)
        {
            int u = MinDistance(distances, visited);
            
            visited[u] = true;
            
            for (int v = 0; v < vertices; v++)
            {
                if (graph[u, v] != 0 && !visited[v] && graph[u, v] < distances[v])
                {
                    parent[v] = u;
                    distances[v] = graph[u, v];
                }
            }
        }
        
        Console.WriteLine("Ребро  Вес");
        for (int i = 1; i < vertices; i++)
        {
            Console.WriteLine(parent[i] + " - " + i + "   " + graph[i, parent[i]]);
        }
    }
    
    public static void Main(string[] args)
    {
        int[,] graph = new int[3, 3] { { 0, 7, 2 }, { 7, 0, 6 }, { 2, 6, 0 } };
        
        PrimsMST(graph, 3);
    }
}
