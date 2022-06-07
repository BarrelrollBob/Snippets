import random as rand

# creates two random arrays - 'c' and 'd' - checks each index of the arrays for 'overlapping' values. If they overlap,
# append to 'overlaps' array

#a = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
#b = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
c = []
d = []
overlaps = []

list_length = input("Enter how many numbers you want there to be in the list: ")
print("Enter the range from which you want to derive numbers for your list: ")
from_range = input()
to_range = input()

for x in range(int(list_length)):
    random_number = rand.randint(int(from_range), int(to_range))
    random_number2 = rand.randint(int(from_range), int(to_range))
    c.append(random_number)
    d.append(random_number2)

print(c)
print(d)

for x in c:
    if x in d:
        print(str(x) + " is present in list d.")
        overlaps.append(x)

print(overlaps)
