def getShortestPath(d,n):
    for u in range(len(d)):
        for v in range(len(d)):
            
            if d[u][v] == float('inf'):
                print("No path found")# между вершинами u и v нет пути
                break
            c = u
            while c != v:
                print('prom',c+1)
                if c==float('inf'): print("No path found"); break
                else: c = (n[c][v]-1)#inf porytit what do if next ver not
            print('kon',v+1)
    
    
def floyd_warshall(graph):
    
    n = max(max(x[:2]) for x in graph)# колво вершин если нумерация с 1
    
    matr_of_dist = [[float('inf')] * n for i in range(n)]# Инициализация матрицы расстояний
    matr_of_nexts=[[float('inf')] * n for i in range(n)]
    
    
    for i in range(n):
        matr_of_dist[i][i] = 0
        
        matr_of_nexts[i][i]=i+1
        
    for u, v, w in graph:
        matr_of_dist[u-1][v-1] = w
        #matr_of_dist[v-1][u-1] = w
        matr_of_nexts[u-1][v-1]=v
        
    # Алгоритм Флойда-Уоршелла
    for k in range(n):
        for i in range(n):
            for j in range(n):
                if (matr_of_dist[i][k] + matr_of_dist[k][j])<matr_of_dist[i][j]:
                    matr_of_dist[i][j] = matr_of_dist[i][k] + matr_of_dist[k][j]
                    matr_of_nexts[i][j]=matr_of_nexts[i][k]
                    
    return matr_of_dist, matr_of_nexts
    
    
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
matr_of_dist, matr_of_nexts = floyd_warshall(graph)
for strin in matr_of_dist:
    print(strin)
for strin in matr_of_nexts:
    print(strin)
    
getShortestPath(matr_of_dist, matr_of_nexts)
