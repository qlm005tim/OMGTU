def readf(fname: str):
    with open(fname) as f:
        N = int(f.readline().strip())
        words = [f.readline().strip() for i in range(N)]#magic words
        
        F = int(f.readline().strip())
        firsts = [f.readline().split() for i in range(F)]#first letters with counts
        
        L = int(f.readline().strip())
        lasts = [f.readline().split() for i in range(L)]
    return N, words, firsts, lasts

def wishcount(fname: str):
    n, words, firsts, lasts = readf(fname)
    countwish = []
    count_wish = []

    for i in range(n):
        for first in firsts:
            for last in lasts:
                
                if words[i][0] == first[0] and words[i][-1] == last[0]:
                    if int(first[1]) > 0 and int(last[1]) > 0:
                        countwish.append(words[i])
                        
                        first[1] = int(first[1]) - 1
                        last[1] = int(last[1]) - 1

    n, words, firsts, lasts = readf(fname)
    
    firsts.sort(key=lambda f: int(f[1]), reverse=True)
    lasts.sort(key=lambda f: int(f[1]), reverse=True)

    for last in lasts:
        for first in firsts:
            for i in range(n):
                if words[i][0] == first[0] and words[i][-1] == last[0]:
                    if int(first[1]) > 0 and int(last[1]) > 0:
                        count_wish.append(words[i])
                        first[1] = int(first[1]) - 1

    c1=len(countwish)
    c2=len(count_wish)
    c = max(c1, c2)
    print(c)

wishcount('input_s1_01zol.txt')
