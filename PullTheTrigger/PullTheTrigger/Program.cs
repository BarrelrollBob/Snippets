namespace PullTheTrigger
{
    class Program
    {
        static void Main(string[] args)
        {
            int rounds = 0;
            int playerWonRounds = 0;
            int computerWonRounds = 0;
            int randomNumber;
            Random rnd = new Random();

            // Loop that runs so long as amount of rounds played is less than 3. Infinite, since when rounds == 3, rounds is set to 0;
            while (rounds <= 3)
            {
                // If rounds == 3, tally up the score - if player has won 2 or more rounds, player wins. Vice versa for the computer. Sets rounds, rounds player has won and rounds computer has won
                // to 0. Finally continue; to next loop, creating infinite loop.
                if (rounds == 3 | playerWonRounds >= 2 | computerWonRounds >= 2)
                {
                    if (playerWonRounds >= 2)
                    {
                        Console.WriteLine($"You won with {playerWonRounds} points! \nThe final score is {playerWonRounds}-{computerWonRounds} in favour of the player!");

                        Console.ReadLine();
                    }

                    if (computerWonRounds >= 2)
                    {
                        Console.WriteLine($"The computer won with {computerWonRounds} points. \nThe final score is {computerWonRounds}-{playerWonRounds} in favour of the computer.");

                        Console.ReadLine();
                    }
                
                    playerWonRounds = 0;
                    computerWonRounds = 0;
                    rounds = 0;
                    continue;
                }
                // ######################################################################################################################

                // If rounds is more than 0 (meaning at least one round has been played) output how many rounds the player and computer has won, if they have won at least 1 round.
                if (rounds > 0)
                {
                    if (playerWonRounds >= 1) 
                    {
                        Console.WriteLine();
                        Console.WriteLine($"You've won {playerWonRounds} round(s).");
                    }

                    if (computerWonRounds >= 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Computer has won {computerWonRounds} round(s)");
                    }
                }
                // #################################################################################################################################################################

                randomNumber = rnd.Next(11);
                rounds++;
                Console.WriteLine($"Round {rounds}!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

                for (int i = 1; i < 11; i++)
                {
                    // Counts once per second, until [i] matches the randomly generated number in randomNumber - then if you input anything before the timer is up (Thread.Sleep), you win.
                    // If you don't, you lose round.
                    Thread.Sleep(1000);
                    Console.WriteLine(i);

                    if (i == randomNumber)
                    {
                        while (Console.KeyAvailable) Console.ReadKey(true);

                        Console.WriteLine("Draw!");
                        Thread.Sleep(350);


                        switch (Console.KeyAvailable)
                        {
                            case true:

                                playerWonRounds++;

                                Console.WriteLine();
                                Console.WriteLine("You shot the opponent!");
                                Thread.Sleep(1000);

                                // Take every input in the input stream, and DON'T output it.
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                // ##########################################################

                                break;

                            case false:

                                computerWonRounds++;

                                Console.WriteLine();
                                Console.WriteLine("The computer shot you!");
                                Thread.Sleep(1000);

                                // Take every input in the input stream, and DON'T output it.
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                // ##########################################################

                                break;
                        }
                        break;
                    // ################################################################################################################################################################
                    }
                }
            }
        }
    }
}
