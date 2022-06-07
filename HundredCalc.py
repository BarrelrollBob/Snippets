
currentYear = 2022

def hundred_when():
    """Function takes your age as input, outputs the year you'll be 100 years old"""

    print("Please enter your age:")
    age = input()

    year_of_birth = str(currentYear - int(age))
    year_hundred = str(currentYear - int(age) + 100)

    print("You were born in " + year_of_birth + ", so you'll be 100 years old in year " + year_hundred + ".")


print(hundred_when.__doc__)
hundred_when()

