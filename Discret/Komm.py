from itertools import permutations

def komm(graph):
    n = len(graph)#count vers
    min_dist = float('inf')
    kom_path = None
    for path in permutations(range(1, n)):
        current_distance = 0
        current_city = 0
        for next_city in path:
            current_distance += graph[current_city][next_city]
            current_city = next_city

        current_distance += graph[current_city][0]

        if current_distance < min_dist:
            min_dist = current_distance
            kom_path = (0,) + path

    return min_dist, kom_path

graph = [
    [0, 41, 17, 23, 32],
    [13, 0, 45, 12, 37],
    [80, 45, 0, 50, 64],
    [23, 12, 50, 0, 67],
    [32, 37, 64, 67, 0]
]

min_dist, kom_path = komm(graph)
print(f"минимальный путь: {min_dist}")
print(f"маршрут коммивояжера: {kom_path}")
