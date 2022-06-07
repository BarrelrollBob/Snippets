# checks whether the input is an even or odd number

def odd_or_even(number, divide):

    mult_four = number % 4
    odd_even = number % 2
    if odd_even < 1:
        print("The number is even")
    if odd_even > 0:
        print("The number is odd")
    if mult_four == 0:
        print("And it's a multiple of 4")
    check = number % divide
    if check == 0:
        print("Your numbers divide evenly")
    else:
        print("Your numbers do not divide evenly")


odd_or_even(-20, 4)
