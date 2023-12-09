sx=int(input())
sy=int(input())
sz=int(input())
fx=int(input())
fy=int(input())
fz=int(input())
a=int(input())
b=int(input())
c=int(input())
if (sx==fx==0 or sx==fx==a) or (sy==fy==0 or sy==fy==b) or (sz==fz==0 or sz==fz==c):
    if (sx==fx==0 or sx==fx==a):
        r=((sy-fy)**2+(sz-fz)**2)**0.5
    if (sy==fy==0 or sy==fy==b):
        r=((sx-fx)**2+(sz-fz)**2)**0.5
    if (sz==fz==0 or sz==fz==c):
        r=((sx-fx)**2+(sy-fy)**2)**0.5
if (sy==0 and fy==b) or (sy==b and fy==0):
    r1=sx+b+((0-fx)**2+(sz-fz)**2)**0.5
    r2=(a-sx)+b+((a-fx)**2+(sz-fz)**2)**0.5
    r3=sz+b+((sx-fx)**2+(0-fz)**2)**0.5
    r4=(c-sz)+b+((sx-fx)**2+(c-fz)**2)**0.5
    r=min(r1,r2,r3,r4)
if (sz==0 and fz==c) or (sz==c and fz==0):
    r1=sx+c+((0-fx)**2+(sy-fy)**2)**0.5
    r2=(a-sx)+c+((a-fx)**2+(sy-fy)**2)**0.5
    r3=sy+c+((sx-fx)**2+(0-fy)**2)**0.5
    r4=(b-sy)+c+((sx-fx)**2+(b-fy)**2)**0.5
    r=min(r1,r2,r3,r4)
if (sx==0 and fx==a) or (sx==a and fx==0):
    r1=sz+a+((sy-fy)**2+(0-fz)**2)**0.5
    r2=(c-sz)+a+((sy-fy)**2+(c-fz)**2)**0.5
    r3=sy+a+((0-fy)**2+(sz-fz)**2)**0.5
    r4=(b-sy)+a+((b-fy)**2+(sz-fz)**2)**0.5
    r=min(r1,r2,r3,r4)
    
if (sy==0 and fz==0) or (fy==0 and sz==0):
    if sy==0 and fz==0:
        r=((sx-fx)**2 + (0 - fy)**2)**0.5
    else: r=((sx-fx)**2 +(0-fz)**2)**0.5
if (sy==0 and fz==c) or (fy==0 and sz==c):
    if sy==0 and fz==c:
        r=((sx-fx)**2 + (0 - fy)**2)**0.5
    else: r=((sx-fx)**2 +(c-fz)**2)**0.5
if (sy==0 and fx==a) or (fy==0 and sx==a):
    if sy==0 and fx==a:
        r=((0-fy)**2 + (sz - fz)**2)**0.5
    else: r=((a-fx)**2 +(sz-fz)**2)**0.5
if (sy==0 and fx==0) or (fy==0 and sx==0):
    if sy==0 and fx==0:
        r=((0-fy)**2 + (sz - fz)**2)**0.5
    else: r=((0-fx)**2 +(sz-fz)**2)**0.5
if (sy==b and fz==0) or (fy==b and sz==0):
    
if (sy==b and fz==c) or (fy==b and sz==c):
    
if (sy==b and fx==a) or (fy==b and sx==a):
    
if (sy==b and fx==0) or (fy==b and sx==0):
    
if (sx==a and fz==0) or (fx==a and sz==0):
    
if (sx==0 and fz==0) or (fx==0 and sz==0):
    
if (sx==a and fz==c) or (fx==a and sz==c):
    
if (sx==0 and fz==c) or (fx==0 and sz==c):
    
