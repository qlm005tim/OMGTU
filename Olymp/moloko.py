f=open('input10.txt')
t=[]#список списков с данными о фирмах
n=int(f.readline())
for i in range(n):
    s=[float(x) for x in f.readline().split()]
    t.append(s)

min_m=float("inf")#минимальная стоимость собственно молока за 1 литр 
num=0#номер фирмы 

for i in range(n):
    x1,y1,z1,x2,y2,z2,c1,c2=t[i][0],t[i][1],t[i][2],t[i][3],t[i][4],t[i][5],t[i][6],t[i][7]
    s1=2*(x1*y1+x1*z1+z1*y1)#площадь поверхности упаковки 
    s2=2*(x2*y2+x2*z2+z2*y2)
    v1=x1*y1*z1#объем упаковки 
    v2=x2*y2*z2
    m=((c2*s1-s2*c1)/(v2*s1-v1*s2))*1000 #стоимость собственно молока за 1 литр 
    num+=1
    if m<min_m:
        min_m=m
        res_num=num
    
print(res_num,round(min_m,2))
