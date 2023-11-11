import math
n=int(input())
def f(n):
    if n<3:
        return 0
    if n==3:
        return 1
    if n>3:
        fp=n//2#math.floor(n/2)
        sp=n//2+(n%2)#math.floor(n/2)+(n%2)
        return f(fp)+f(sp)
print(f(n))
