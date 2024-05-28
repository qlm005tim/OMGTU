def floyd_warshall(graph):
    
    n = max(max(x[:2]) for x in graph)# колво вершин если нумерация с 1
    
    matr_of_dist = [[float('inf')] * n for i in range(n)]# Инициализация матрицы расстояний
    
    for i in range(n):
        matr_of_dist[i][i] = 0
    
    for u, v, w in graph:
        matr_of_dist[u-1][v-1] = w
        #matr_of_dist[v-1][u-1] = w
    
    # Алгоритм Флойда-Уоршелла
    for k in range(n):
        for i in range(n):
            for j in range(n):
                if (matr_of_dist[i][k] + matr_of_dist[k][j])<matr_of_dist[i][j]:
                    matr_of_dist[i][j] = matr_of_dist[i][k] + matr_of_dist[k][j]

    return matr_of_dist
    
graph = [
            [1, 2, 1],
            [1, 3, 4],
            [2, 3, 2],
            [2, 4, 5],
            [3, 4, 1],
            [3, 5, 3],
            [4, 5, 2]
            ]

            # Вычисление матрицы расстояний
matr_of_dist = floyd_warshall(graph)
for strin in matr_of_dist:
    print(strin)
