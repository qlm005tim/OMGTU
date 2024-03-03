import heapq
graph=[[15,1,2],[14,1,5],[23,1,4],[19,2,3],[16,2,4],[15,2,5],[14,3,5],[26,3,6],[25,4,5],[23,4,7],[20,4,8],[24,5,6],[27,5,8],[18,5,9],[14,7,8],[18,8,9]]

def v(graph):
    v=[]
    for x in graph:
        if (x[1] not in v):
            v.append(x[1])
        if (x[2] not in v):
            v.append(x[2])
    return v
    
def msm(graph):
    ver=v(graph)
    cver=len(ver)
    
    sm={verr:[] for verr in ver}
    for i in range(len(graph)):
        wt, x1, y1=graph[i]
        sm[x1].append([wt,y1])
        sm[y1].append([wt,x1])
    return sm
                
def prim(graph):
    sm=msm(graph)
    cver=len(v(graph))

    res=0
    visited=set()
    minheap=[[0,graph[0][1]]]
    
    while len(visited)<cver:
        cost, x=heapq.heappop(minheap)
        if x in visited:
                continue
        res+=cost
        visited.add(x)
        for neighbourcost, neighbour in sm[x]:
            if neighbour not in visited:
                heapq.heappush(minheap, [neighbourcost, neighbour])
    return res
    
print(prim(graph))
