
# guess a number

import random as rand
guess = 0
game_state = True

while game_state:
    n = int(input("Pick a number to define the range from which the computer will generate a random number. "))
    ran = rand.randint(1, n)
    print("The number has been generated.")
    print("Type '0' any time to exit the game")
    while guess != ran:
        guess = int(input("Guess the number"))
        if guess == 0:
            game_state = False
            break
        if guess < ran:
            print(f"{guess} is too low! \n")
        elif guess > ran:
            print(f"{guess} is too high! \n")
        else:
            print(f"{guess} is correct! \n")

            repeat = input("Congratulations! Do you want to play again? yes/no")
            while repeat not in ('no', 'yes'):
                    repeat = input("Oops - I didn't understand that. Type 'yes' or 'no'")
                    
                if repeat.lower() == 'yes':
                    guess = 0
                    break
                elif repeat.lower() == 'no':
                    game_state = False
