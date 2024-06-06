
//алгоритм шир_ для поиска компонент связности
graph = [
        [0, 1],
        [0, 2],
        [2, 1],
        
        [4, 3],
        [3, 5],
        [5, 8],
        [9, 3],
        [9, 7],
        [7, 6],

        [10, 11],
        [10, 12],
        [10, 13],
        [10, 14],
        [10, 15],
]

def Vers(graph):
    vers = set()

    for x in graph:
        vers.add(x[0])
        vers.add(x[1])
    return sorted(list(vers))

def Components(graph):
    components = [set()]

    free = Vers(graph)

    components[0].add(graph[0][0])
    components[0].add(graph[0][1])

    free.remove(graph[0][0])
    free.remove(graph[0][1])

    while len(free) > 0:
        for x in graph:
            for i in range(len(components)):
                comp = components[i]
                if x[0] in comp or x[1] in comp:
                    comp.add(x[0])
                    comp.add(x[1])

                    if x[0] in free:
                        free.remove(x[0])
                    if x[1] in free:
                        free.remove(x[1])

                else:
                    if i == len(components) - 1:
                        c = set()
                        c.add(x[0])
                        c.add(x[1])
                        components.append(c)

                    if x[0] in free:
                        free.remove(x[0])
                    if x[1] in free:
                        free.remove(x[1])

    return components

print(Components(graph))
