m=[]
with open('C:\\Зельеварение\\input10.txt', 'r') as f:
    m+=f.readlines()
#print(m)
for i in range(len(m)):
    if "DUST" in m[i]:
        m[i] = m[i].replace("DUST", "DT", 1)
        m[i] += " TD"
    if "FIRE" in m[i]:
        m[i] = m[i].replace("FIRE", "FR", 1)
        m[i] += " RF"
    if "MIX" in m[i]:
        m[i] = m[i].replace("MIX", "MX", 1)
        m[i] += " XM"
    if "WATER" in m[i]:
        m[i] = m[i].replace("WATER", "WT", 1)
        m[i] += " TW"



def is_number(s):
    try:
        float(s)
        return True
    except ValueError:
        return False


for i in range(len(m)):
    if ("0" in m[i]) or ("1" in m[i]) or ("2" in m[i]) or ("3" in m[i]) or ("4" in m[i]) or ("5" in m[i]) or (
            "6" in m[i]) or ("7" in m[i]) or ("8" in m[i]) or ("9" in m[i]):
        pol = m[i].split(" ")
        for j in range(len(pol)):
            if is_number(pol[j]):
                pol[j] = m[int(pol[j]) - 1]
        m[i] = " ".join(pol)

print('\n'+ str(m[-1]))