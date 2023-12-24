fname = f'input_s1_01.txt'
with open(fname) as f:
    X, Y, L, C1, C2, C3, C4, C5, C6 = [int(i) for i in f.readline().split(' ')]
P = 2*(X + Y) 
repaired = 0
rebuilt = 0
neww = 0
ost = L
if C1 < C2 + C3 and C1 <= C2 + C4 + C5 + C6:
    repaired = min(L, max(X, Y))
    P -= repaired
    ost -= repaired

if C2 + C3 < C2 + C4 + C5 + C6:
    rebuilt = min(ost, P)
    ost -= rebuilt
    P -= rebuilt

neww = P
mins = repaired * C1 + rebuilt * (C2 + C3) + neww * (C4 + C5) + ost * (C2 + C6)
print(f'Минимальная сумма: {mins}')
