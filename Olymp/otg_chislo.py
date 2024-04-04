fname = 'input_s1_01.txt'
with open(fname, 'rt') as f:
    running_sum = [0, 1]

    count = f.readline()
    for i in range(int(count)):
        operation, num = f.readline().strip().split()

        if num != 'x':
            if operation == '+':
                running_sum[0] += int(num)
            elif operation == '-':
                running_sum[0] -= int(num)
            elif operation == '*':
                running_sum[0] *= int(num)
                running_sum[1] *= int(num)
        elif num == 'x':
            if operation == '+':
                running_sum[1] += 1
            elif operation == '-':
                running_sum[1] -= 1

    res = int(f.readline())

ans = (res - running_sum[0]) / running_sum[1]
print(ans)