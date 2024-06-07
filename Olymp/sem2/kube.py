for j in [f"{i:02}" for i in range(1, 21)]:
    file = open(f"input_s1_{j}.txt")
    file_out = open(f"output_s1_{j}.txt").readline()
    line = file.readline().strip()
    n, m = map(int, line.split())
    line = file.readline().strip()
    xPos, yPos, zPos = map(int, line.split())
    
    for _ in range(m):
        line = file.readline().strip()
        axis, cord, dirr = line.split()
        cord = int(cord)
        dirr = int(dirr)
        if axis == "X":
            if xPos == cord:
                if dirr > 0:
                    tmp = zPos
                    zPos = n + 1 - yPos
                    yPos = tmp
                else:
                    tmp = yPos
                    yPos = n + 1 - zPos
                    zPos = tmp
        elif axis == "Y":
            if yPos == cord:
                if dirr > 0:
                    tmp = zPos
                    zPos = n + 1 - xPos
                    xPos = tmp
                else:
                    tmp = xPos
                    xPos = n + 1 - zPos
                    zPos = tmp
        elif axis == "Z":
            if zPos == cord:
                if dirr > 0:
                    tmp = yPos
                    yPos = n + 1 - xPos
                    xPos = tmp
                else:
                    tmp = xPos
                    xPos = n + 1 - yPos
                    yPos = tmp
    print(f"{xPos} {yPos} {zPos}")
    if f"{xPos} {yPos} {zPos}" == file_out:
        print("True")
    else:
        print("False")
