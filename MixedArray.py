# a program that iterates through an array of different datatypes - if the index is a number, print it.
# If not a number, collect it in an array. Finally print the array.

#import txt as hi

rand_array = [1, 3, "hi", 5, True, 3.1, 3.2, "hello", "bye", 42059301, 1, 3, "he", [], 5]
false_array = []
for x in rand_array:
    if type(x) != list and type(x) != str and type(x) != float and type(x) != bool or type(x) == int:
        print(x)
    else:
        print("Not an int")
        false_array.append(x)
print(false_array)
