n=int(input())
def f(n):
    if n<3:
        return 0
    elif n==3:
        return 1
    elif n>3:
        n1=n//2
        n2=n//2+(n%2)
        return f(n1)+f(n2)
print(f(n))
