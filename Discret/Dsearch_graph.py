#deep search
graph = [
        [1, 2],
        
        [3, 4],
        [3, 5],
        [4, 5],
        
        [6, 7],
        [6, 8],
        [7, 9],
        [7, 10],
        [8, 10],
        [8, 12],
        [8, 13],
        [9, 11],
        [10, 11],
        [11, 12],
        [12, 13],
]

def Vers(graph):
    vers = set()

    for x in graph:
        vers.add(x[0])
        vers.add(x[1])

    return sorted(list(vers))

def Components(graph):
    components = []

    ver_list = Vers(graph)
    graph_copy = graph.copy()

    while len(ver_list) > 0:
        componentNow = set()
        componentNow.add(ver_list.pop(0))
        for ver in graph_copy:
            if ver[0] in componentNow or ver[1] in componentNow:
                componentNow.add(ver[0])
                componentNow.add(ver[1])

                if ver[0] in ver_list:
                    ver_list.remove(ver[0])
                if ver[1] in ver_list:
                    ver_list.remove(ver[1])

        components.append(componentNow)

        graph_copy = [ver for ver in graph_copy if ver[0] not in componentNow and ver[1] not in componentNow]

    return components
    
print(Components(graph))
