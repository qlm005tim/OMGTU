def dijkstra(graph, start):
    
    n=max(max(x[0:2]) for x in graph)#количество вершин в графе
    
    distances={vertex: float('infinity') for vertex in range(1,n+1)}#словарь для хранения минимальных расстояний от start до всех вершин
    
    
    paths = {vertex: [] for vertex in range(1, n+1)}# словарь для путей, ключи-вершины к котрым идем из старт, значения-массивы для путей 
    
    distances[start] = 0# Расстояние от start до самого себя равно 0
    
    paths[start] = [start]# путь от вершины стартовой из нее в нее только по ней проходит
    
    visited = set()# множество для отслеживания посещенных вершин

    
    while len(visited) < n:
        
        current_vertex = min(set(distances.keys()).difference(visited))# вершина с наименьшим расстоянием, которая еще не была посещена
            
        visited.add(current_vertex)# Посещаем выбранную вершину

        for x in graph:# Обновляем расстояния через текущую вершину до соседних
            if x[0] == current_vertex:
                new_distance = distances[current_vertex] + x[2]
                
                if new_distance < distances[x[1]]: # Проверяем, не улучшает ли новое расстояние путь
                    distances[x[1]] = new_distance
                    paths[x[1]]=paths[current_vertex]+[x[1]]#добавляем текущую вершину к пути до соседней
                
    return distances, paths

graph = [
    
    [1, 2, 5],
    [1, 5, 2],
    [1, 6, 4],
    [2, 3, 12],
    [2, 6, 1],
    [3, 4, 9],
    [3, 6, 3],
    [4, 5, 7],
    [4, 6, 10],
    [5, 6, 8],
]
start = 1

distances,paths=dijkstra(graph, start)
print(distances)
print(paths)
