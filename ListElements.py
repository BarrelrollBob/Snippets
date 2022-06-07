# prompts for an input. Loops through the 'a', checking each index. If it's 'less' than or equal to user_input, append
# a[x]  to array 'b'

a = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
b = []
user_input = input("Gimme value")

for x in a:
    if x <= int(user_input):
        b.append(x)
        b.sort()
print(b)
