#  алгоритм Форда-Беллмана
def ford_bellman(W, start, N):
    INF = 10 ** 9
    F = [INF] * N
    Prev = [None] * N
    F[start] = 0

    for k in range(1, N):
        for j, i in W.keys():
            if F[j] + W[j, i] < F[i]:
                F[i] = F[j] + W[j, i]
                Prev[i] = j

    path = []
    node = N - 1
    while node is not None:
        path.append(node)
        node = Prev[node]
    path.reverse()

    return F[N - 1], path


W = {(0, 1): 5, (0, 4): 1, (1, 2): 2, (1, 3): 6, (1, 4): 2, (2, 3): 5, (3, 4): 4, (4, 1): 1}
start = 2
N = 5
distance, path = ford_bellman(W, start, N)
print(f"Длина кратчайшего пути: {distance}")
print(f"Кратчайший путь: {' -> '.join(map(str, path))}")
