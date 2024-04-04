graph = [
    [0, 1, 19],
    [1, 2, 35],
    [2, 3, 13],
    [1, 3, 46],
    [2, 4, 34],
    [4, 5, 23],
    [4, 7, 67],
    [5, 6, 23],
    [7, 8, 13],
    [6, 9, 64],
    [1, 5, 97],
]

Vers = [1, 2, 3, 4, 5, 6, 7, 8, 9]
Ribs = [
    [0, 1],
    [1, 2],
    [2, 3],
    [1, 3],
    [2, 4],
    [4, 5],
    [4, 7],
    [5, 6],
    [7, 8],
    [6, 9],
    [1, 5],
]
Weights = [19, 35, 13, 46, 34, 23, 67, 23, 13, 64, 97]
start = 1
ended=6
s = [start]

minDistances = {start: 0}

used = [1]
index = 0
for i in range(len(Ribs)):
    if Ribs[i][0] == start:
        minDistances[Ribs[i][1]] = Weights[i]
        used.append(Ribs[i][1])

for i in Vers:
    if used.count(i) == 0:
        minDistances[i] = float("inf")

while True:
    curElem = s[index]
    possibleVers = []
    possibleWeights = []

    for i in range(len(Ribs)):
        if Ribs[i][0] == curElem:
            possibleVers.append(Ribs[i][1])
            possibleWeights.append(Weights[i])

    for i in possibleVers:
        if s.count(i) == 0:
            value = min(
                minDistances[i],
                minDistances[curElem]
                + possibleWeights[possibleVers.index(i)],
            )
            minDistances[i] = value

    minWeights = float("inf")
    for key, value in minDistances.items():
        if s.count(key) == 0:
            if value < minWeights:
                minWeights = value
                minRibs = key
    if minRibs != ended:
        s.append(minRibs)
        index += 1
    else:
        minDistances[minRibs] = minDistances[minRibs] + possibleWeights.index(
            min(possibleWeights)
        )
        break

res = minDistances[ended]

path = [ended]

for i in range(0, len(Vers)):
    leng = 0
    pair = [Vers[i], path[-1]]
    for j in range(len(Ribs)):
        if Ribs[j] == pair:
            leng = Weights[j]
            break
    if minDistances[Vers[i]] + leng == res:
        path.append(Vers[i])
        res -= leng
path.append(start)

print(f"кратчайший путь: {res}")
print(f"Маршрут кратчайшего пути: {path}")
print(f"Кратчайшие пути для каждой вершины из вершины {start}: {minDistances}")