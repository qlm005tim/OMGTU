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
    
def mst(graph):
    vers=v(graph)
    
    st={verr:[] for verr in vers}
    for i in range(len(graph)):
        wt, x1, y1=graph[i]
        st[x1].append([wt,y1])
        st[y1].append([wt,x1])
    return st
                
def prim(graph):
    sm=mst(graph)
    cver=len(v(graph))

    res=0
    mod=[]
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
                mod.append([x, neighbour])
    return res,mod
    
res,mod=prim(graph)
print(res)
print(mod)
