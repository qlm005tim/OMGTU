print('Постройка дома')

filename = f'input_s1_01.txt'

with open(filename) as f:
    X, Y, L, C1, C2, C3, C4, C5, C6 = [int(i) for i in f.readline().split(' ')]

whole_wall = 2*X + 2*Y

repaired_wall = 0
rebuilt_wall = 0
new_wall = 0
remainder = L

if C1 < C2 + C3 and C1 <= C2 + C4 + C5 + C6:
    repaired_wall = min(L, max(X, Y))
    whole_wall -= repaired_wall
    remainder -= repaired_wall

if C2 + C3 < C2 + C4 + C5 + C6:
    rebuilt_wall = min(remainder, whole_wall)
    remainder -= rebuilt_wall
    whole_wall -= rebuilt_wall

new_wall = whole_wall

min_cost = repaired_wall * C1 + rebuilt_wall * (C2 + C3) + new_wall * (C4 + C5) + remainder * (C2 + C6)

print(f'Минимальная сумма: {min_cost}')


x= int(input())
y= int(input()) 
l= int(input())
c1= int(input())
c2= int(input())
c3= int(input())
c4= int(input())
c5= int(input())
c6= int(input())
p=(x+y)*2
if l>= max( x, y):
    v1=c1*(min(x, y))+(c2+c3)*(l-min(x,y))+(c4+c5)*(p-l)
    v2=c1*(max(x, y))+(c2+c3)*(l-max(x,y))+(c4+c5)*(p-l)
    v3=c1*(min(x, y))+(c2+c6)*(l-min(x,y))+(c4+c5)*(p-min(x, y))
    v4=c1*(max(x, y))+(c2+c3)*(l-max(x,y))+(c4+c5)*(p-max(x, y))
    v5=(c2+c6)*l+(c4+c5)*p
    v6=(c2+c3)*l+(c4+c5)*(p-l)
    v= min(v1, v2, v3, v4, v5, v6)
if l<= min(x, y):
    v1=c1*l+(c4+c5)*(p-l)
    v2=(c2+c3)*l+(c4+c5)*(p-l)
    v3=(c2+c6)*l+(c4+c5)*p
    v=min(v1, v2, v3)
if min(x, y)<l<max(x, y):
    v1=c1*l+(c4+c5)*(p-l)
    v2=c1*min(x, y)+(c2+c3)*(l-min(x, y))+(c4+c5)*(p-l)
    v3=c1*min(x, y)+(c2+c6)*(l-min(x, y))+(c4+c5)*(p-min(x, y))
    v4=(c2+c6)*l+(c4+c5)*p
    v=min(v1, v2, v3, v4)
print(v)