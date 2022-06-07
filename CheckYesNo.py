
# A check loop - if the user enters yes, or anything other than 'no', the program runs continuously. Program only
# terminates once 'no' is input

state = True

while state:
    test = input("type yes or no")
    while test == 'yes' or test == 'no':
        if test == 'yes':
            print('Wow!')  # indicates the user input 'yes'
            break
        elif test == 'no':
            state = False
            print('Aww!')  # indicates the user input 'no'
            break
        else:
            test = input("Oops, I didn't quite get that - type 'yes' or 'no'")

        continue
