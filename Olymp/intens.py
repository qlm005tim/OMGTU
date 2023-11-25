nach=str(input())
kon=str(input())
p=int(input())
nd=int(nach.split('.')[0])
nm=int(nach.split('.')[1])
ny=int(nach.split('.')[2])
kd=int(kon.split('.')[0])
km=int(kon.split('.')[1])
ky=int(kon.split('.')[2])

def year(y):
    if y%4==0:
        return [0,31,29,31,30,31,30,31,31,30,31,30,31]
    else:
        return [0,31,28,31,30,31,30,31,31,30,31,30,31]

def count_vis(ny,ky):
    count=0
    for i in range(ny,ky):
        if i%4==0:
            count+=1
    return count        

n=0        
if ky==ny and nm!=km: n=(year(ny)[nm]-nd)+sum(year(ny)[nm+1:km])+kd+1
elif ky==ny and nm==km: n=kd-nd+1
elif ky!=ny: 
    if ky==ny+1: n=(year(ny)[nm]-nd+1)+sum(year(ny)[nm+1:])+sum(year(ky)[:km])+kd
    else: n=(year(ny)[nm]-nd+1)+sum(year(ny)[nm+1:])+(365*(ky-ny-1)+count_vis(ny+1,ky))+sum(year(ky)[:km])+kd
print(n)
print(0.5*n*(2*p+(n-1)*1))
