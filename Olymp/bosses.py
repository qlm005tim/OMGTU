d={}
l=input().split(maxsplit=1) 
while l!= ["END"]:
    if len(l) ==1:
        d.setdefault(l[0], "Unknown Name") 
    else:
        d.setdefault(l[0], l[1]) 
    l=input().split(maxsplit=1) 
print(d) 

boss=input() 
new_d=d.copy() 
if ' ' in boss:
    for key,value in d.items():
        if value==boss:
            del new_d[key]
else:
    del new_d[boss]

sorted_d=sorted(new_d.items(), key=lambda item: item[0]) 
print(sorted_d) 