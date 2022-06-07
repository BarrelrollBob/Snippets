﻿using VendingMachine.Classes;

// Problems that arose & revelations I had:
// - Not listing constructor parameters in the order they were in
// - Forgetting that namespaces between classes and files had to align (more of an oversight than ignorance. And I don't know how to call namespaces yet)
// - Thinking it was impossible to loop through a list of objects without black magic(methods/voodoo suggestions from internet people) - can instantiate objects to Object array indexes. 
// didn't even have to touch Lists - for some reason the array could expand dynamically? (actually not sure if I can add/remove elements, but I think I can since I haven't specified # of elements)
// - Foreach is read-only, for is not (can't change the attributes of the object iterated upon using foreach)
// - 'var' has to be initialized, and when it is, its type is static/fixed
// - I need to learn Lists<>, the code would be much cleaner and easier to write if I did. I wouldn't have to deal with 3 foreach loops, for one
// - You can't typecast from void
// TBA:

// TODO: Have an option to add items to each category.
// TODO: Method for sorting items in a specific order based on category, and changing itemNumber depending on that order. 
// For example: if the order is [Crisps1, Lasagna2, Pizza3, Water4], have it be [Pizza1, Lasagna2, Crisps3, Water4] instead. Food > Snack > Drink. Have it sort again when an item is added.
// TODO: Show items you can afford  

namespace VendingMachine.Classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            var foodItem = new Foods[]
            {
                new Foods("Spaghetti", 1, 45, true),
                new Foods("Pizza", 2, 30, true),
                new Foods("Lasagna", 3, 40, true)
            };

            var snackItem = new Snacks[]
            {
                new Snacks("Chocolate bar", 4, 20, true),
                new Snacks("Crisps", 5, 15, true),
                new Snacks("Peanuts", 6, 20, true)
            };

            var drinkItem = new Drinks[]
            {
                new Drinks("Water", 7, 10, true),
                new Drinks("Soda", 8, 15, true),
                new Drinks("Beer", 9, 20, true)
            };

            int? balance = 0;

            bool state = true;

            Console.WriteLine("Type 'getAll' if you want to display all items");
            Console.WriteLine("Type 'get' if you want to purchase an item");
            Console.WriteLine("Type 'quit' to terminate the program");
            Console.WriteLine("Type 'insert' to insert money into the machine");
            
            while (state)
            {
                string pleb = "";
                string helper = "hello";
                char[] keyArray = helper.ToCharArray();
                for (int i = 0; i < keyArray.Length - 1; i++)
                {
                    pleb += Convert.ToString(keyArray[i]);
                }

                Console.WriteLine(pleb);
                string? userInput = Console.ReadLine();

                if (userInput == "getAll") getAllItems();
                else if (userInput == "get") getItem();
                else if (userInput == "insert") setBalance();
                else if (userInput == "quit") state = false;
                else Console.WriteLine("Not a correct input. Try again.");
                
            }

            // Displays all items in the vending machine:
            void getAllItems()
            {
                Console.WriteLine("Available Dishes:");

                foreach (var item in foodItem)
                {
                    Console.WriteLine($" #{item.ItemNumber} : {item.Name}");
                }
                Console.WriteLine("-----------------");

                Console.WriteLine("Assortment of snacks:");

                foreach (var item in snackItem)
                {
                    Console.WriteLine($" #{item.ItemNumber} : {item.Name}");
                }
                Console.WriteLine("-----------------");

                Console.WriteLine("Ice cold beverages:");

                foreach (var item in drinkItem)
                {
                    Console.WriteLine($" #{item.ItemNumber} : {item.Name}");
                }
            }
            // Gets an item in the chosen category - loops through one of 3 arrays, which one it loops through depends on the user input in the {category} variable:
            void getItem()
            {
                string? userChoice = "";
                string? category = "";

                Console.WriteLine("Do you want food, a snack or a drink?");
                category = Console.ReadLine();


                if (category.ToLower() == "food")
                {
                    int i = 0;

                    Console.WriteLine($"Choose a {category} item:");
                    userChoice = Console.ReadLine();

                    foreach (var item in foodItem)
                    {
                        if (firstLetterCapital(userChoice) == item.Name)
                        {
                            if (balance - item.ItemCost < 0)
                            {
                                Console.WriteLine($"Sorry, you can't afford this item. Insert money into the machine to complete the purchase. Your current balance is: {balance}.");
                                break;
                            }
                            else if (balance - item.ItemCost >= 0)
                            {
                                balance -= item.ItemCost;
                                Console.WriteLine($"You chose {userChoice}. It'll be {item.ItemCost}. Your balance is now: {balance}");
                                break;
                            }
                        }
                        else // Instead of having the message below printed three times, have some logic ensure that if the loop ever runs to completion without getting a match, display the message once:
                        {
                            i++;
                            if (i == foodItem.Length)
                            {
                                Console.WriteLine($"Sorry, '{userChoice}' is not on the menu.");
                                break;
                            }
                            else continue;
                        }
                    }
                }


                else if (category.ToLower() == "snack")
                {
                    int i = 0;

                    Console.WriteLine($"Choose a {category}:");
                    userChoice = Console.ReadLine();
                    foreach (var item in snackItem)
                    {
                        if (firstLetterCapital(userChoice) == item.Name)
                        {
                            if (balance - item.ItemCost < 0)
                            {
                                Console.WriteLine($"Sorry, you can't afford this item. Insert money into the machine to complete the purchase. Your current balance is: {balance}.");
                                break;
                            }
                            else if (balance - item.ItemCost >= 0)
                            {
                                balance -= item.ItemCost;
                                Console.WriteLine($"You chose {userChoice}. It'll be {item.ItemCost}. Your balance is now: {balance}");
                                break;
                            }
                        }
                        else // Instead of having the message below printed three times, have some logic ensure that if the loop ever runs to completion without getting a match, display the message once:
                        {
                            i++;
                            if (i == snackItem.Length)
                            {
                                Console.WriteLine($"Sorry, '{userChoice}' is not on the menu.");
                                break;
                            }
                            else continue;
                        }
                    }
                }


                else if (category.ToLower() == "drink")
                {
                    int i = 0;

                    Console.WriteLine($"Choose a {category}:");
                    userChoice = Console.ReadLine();
                    foreach (var item in drinkItem)
                    {
                        if (firstLetterCapital(userChoice) == item.Name)
                        {
                            if (balance - item.ItemCost < 0)
                            {
                                Console.WriteLine($"Sorry, you can't afford this item. Insert money into the machine to complete the purchase. Your current balance is: {balance}.");
                                break;
                            }
                            else if (balance - item.ItemCost >= 0)
                            {
                                balance -= item.ItemCost;
                                Console.WriteLine($"You chose {userChoice}. It'll be {item.ItemCost}. Your balance is now: {balance}");
                                break;
                            }
                        }
                        else // Instead of having the message below printed three times, have some logic ensure that if the loop ever runs to completion without getting a match, display the message once:
                        {
                            i++;
                            if (i == drinkItem.Length)
                            {
                                Console.WriteLine($"Sorry, '{userChoice}' is not on the menu.");
                                break;
                            }
                            else continue;
                        }
                    }
                }
            }
            // Sets the balance - ensures balance cannot exceed 1000:
            void setBalance()
            {
                Console.WriteLine("Insert money:");
                string? userInput = Console.ReadLine();
                bool canParse = int.TryParse(userInput, out int amountOfMoney);

                if (canParse == true)
                {
                    if (amountOfMoney > 1000) Console.WriteLine("Lol you don't have that much money peasant XDDDDDDDDD!!11!1!");
                    else if (amountOfMoney + balance > 1000) Console.WriteLine($"Your balance cannot exceed 1000. Your current balance is: {balance}");
                    else Console.WriteLine($"The money has been inserted, your balance is now: {balance += amountOfMoney}.");
                }
                else Console.WriteLine("Sorry, that's not a valid input.");
            }
            // Ensures uniform user input - whether the user inputs 'abcd', 'aBcD', 'abCD', 'ABCD' etc., the input will always compile to 'Abcd'.
            // The reason I did this was because each snack, drink and food object is instantiated with a capital letter in the 'Name'. 
            // I could've instantiated them with all lowercase letters, but realized the issue late and wanted to try doing it by method for fun.
            // I use this method in the 'getItem' method, where if the user before typed 'pizza' to get an item, where the item was instantiated
            // with name 'Pizza', it'd throw an error.
            string firstLetterCapital(string word)
            {
                word = word.ToLower();
                char[] wordToChar = word.ToCharArray();
                word = "";
                wordToChar[0] = char.ToUpper(wordToChar[0]);
                foreach (char c in wordToChar) word += char.ToString(c);
                return word;
            }
        }
    }
}