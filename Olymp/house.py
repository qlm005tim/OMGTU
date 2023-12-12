
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