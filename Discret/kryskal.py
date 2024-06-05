graph=[[15,1,2],[14,1,5],[23,1,4],[19,2,3],[16,2,4],[15,2,5],[14,3,5],[26,3,6],[25,4,5],[23,4,7],[20,4,8],[24,5,6],[27,5,8],[18,5,9],[14,7,8],[18,8,9]]
#matrix smegnosti weight, start, finish
def v(graph):
    v=[]
    for x in graph:
        if (x[1] not in v):
            v.append(x[1])
        if (x[2] not in v):
            v.append(x[2])
    return v
    
def kruskal(graph):
    res=0
    m=[]#vers inz rebram mod
    mod=[]
    graph=sorted(graph,key=lambda x: x[0])
    
    m.append(graph[0][1])
    m.append(graph[0][2])
    res+=graph[0][0]
    mod.append([graph[0][1], graph[0][2]])
    
    while len(m) < len(v(graph)):
        for x in graph:
            if x[1] in m and x[2] not in m:
                m.append(x[2])
                res+=x[0]
                mod.append([x[1],x[2]])
                break
            if x[1] not in m and x[2] in m:
                m.append(x[1])
                res+=x[0]
                mod.append([x[1],x[2]])
                break
    return res, mod

mod_weight, mod= kruskal(graph) 
print(mod_weight)
print(mod)
