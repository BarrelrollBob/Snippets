# get all the divisors of a given number
# divisor = number that divides another number evenly (returns 0)

number = 12
b = []
for x in range(int(number)):
    if x != 0:
        a = int(number) % x
        if a == 0:
            print(x)
            b.append(x)


