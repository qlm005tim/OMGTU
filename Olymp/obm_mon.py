l = [int(x) for x in input().split()][1:] 
lunhap = sorted([int(x) for x in input().split()][1:], reverse=True)
t = [int(x) for x in input().split()][1:] 
tunhap = sorted([int(x) for x in input().split()][1:])
moneyl = [int(x) for x in input().split()]
realmon = 0

for index, n in enumerate(moneyl):
    for unhap in lunhap:
        if n > unhap:
            n -= 1
    for perev in l[index:]:
        n *= perev
    realmon += n
    
c = []
for perev in reversed(t):
    c += [realmon % perev]
    realmon //= perev
c += [realmon]
for index, n in enumerate(c):
    for unhap in tunhap:
        if n >= unhap:
            n += 1
    c[index] = n
for i in reversed(c):
    print(i, end=" ")
