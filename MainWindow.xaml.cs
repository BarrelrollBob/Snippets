using System;
using System.Windows;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // defines input
        string keyNum = "";
        // variable where amount of money inserted in the machine is stored
        int? balance = 0;
        // keyNum parsed to string (minus #)
        int num = 0;

        public Foods[] foodItem = new Foods[]
            {
                new Foods("Spaghetti", 1, 45, true),
                new Foods("Pizza", 2, 30, true),
                new Foods("Lasagna", 3, 40, true)
            };

        public Snacks[] snackItem = new Snacks[]
        {
                new Snacks("Chocolate bar", 4, 20, true),
                new Snacks("Crisps", 5, 15, true),
                new Snacks("Peanuts", 6, 20, true)
        };

        public Drinks[] drinkItem = new Drinks[]
        {
                new Drinks("Water", 7, 10, true),
                new Drinks("Soda", 8, 15, true),
                new Drinks("Beer", 9, 20, true)
        };
        public MainWindow()
        {
            InitializeComponent();
            txtblckMenu.Text = getAllItems();
        }


        // Button 1-9
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "1";
            keyNum += "1";
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "2";
            keyNum += "2";
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "3";
            keyNum += "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "4";
            keyNum += "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "5";
            keyNum += "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "6";
            keyNum += "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "7";
            keyNum += "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "8";
            keyNum += "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "9";
            keyNum += "9";
        }

        // "0" button
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "0";
            keyNum += "0";
        }

        // 'Delete' button
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string helper = "";
            char[] keyArray = keyNum.ToCharArray();
            for (int i = 0; i < keyArray.Length - 1; i++)
            {
                helper += keyArray[i];
            }
            keyNum = helper;
            txtblckTerminal.Text = keyNum;

        }
        // 'Hash Key' button
        private void btnHash_Click(object sender, RoutedEventArgs e)
        {
            txtblckTerminal.Text += "#";
            keyNum += "#";
        }

        // 'Enter' button / where the magic happens
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            bool canParse = int.TryParse(keyNum, out int number);
            num = number;
            
            // If keyNum can be parsed to an int, call getItem():
            if (canParse) getItem();
            
            // initiator for setBalance() - if the first char in keyNum == #, parse 'keyNum'
            // to 'num', minus the '#':
            else if (keyNum[0] == '#')
            {
                string helper = "";
                char[] keyArray = keyNum.ToCharArray();
                
                for (int i = 1; i < keyArray.Length; i++) helper += keyArray[i];
                
                bool canParseHelper = int.TryParse(helper, out int helperNum);
                // if helper THEN can be parsed (if it doesn't contain '#' in it
                // somewhere)
                if (canParseHelper)
                {
                    num = Convert.ToInt32(helperNum); // Already int, not sure why I'm casting
                    setBalance();
                }
                else txtblckTerminal.Text = "Sorry, that's not a valid input.";
                
            }
            
            else if (keyNum == "") txtblckTerminal.Text = "Input a number: \n";

            else txtblckTerminal.Text = "Sorry, that's not a valid input.";

            keyNum = "";
        }

        // Displays all items in the vending machine:
        public string getAllItems()
        {
            txtblckMenu.Text += ("Available Dishes:\n");

            foreach (var item in foodItem)
            {
                txtblckMenu.Text += ($" #{item.ItemNumber} : {item.Name} - price: {item.ItemCost}\n");
            }
            txtblckMenu.Text += ("-----------------\n");

            txtblckMenu.Text += ("Assortment of snacks:\n");

            foreach (var item in snackItem)
            {
                txtblckMenu.Text += ($" #{item.ItemNumber} : {item.Name} - price: {item.ItemCost}\n");
            }
            txtblckMenu.Text += ("-----------------\n");

            txtblckMenu.Text += ("Ice cold beverages:\n");

            foreach (var item in drinkItem)
            {
                txtblckMenu.Text += ($" #{item.ItemNumber} : {item.Name} - price: {item.ItemCost}\n");
            }
            return txtblckMenu.Text;
        }

        // Loops through each Object array searching for an item - if the item doesn't exist, write error message:
        public void getItem()
        {
            int i = 0;

            foreach (var item in foodItem)
            {
                // if num is == current item.ItemNumber:
                if (num == item.ItemNumber)
                {
                    // then if your balance is < 0, error message:
                    if (balance - item.ItemCost < 0)
                    {
                        txtblckTerminal.Text = ($"Sorry, you can't afford this item. Insert money into the machine to complete the purchase. Your current balance is: {balance}.");
                        keyNum = "";
                        break;
                    }
                    // else if your {balance - num} is greater than 0, buy the item (num is the input parsed to int):
                    else if (balance - item.ItemCost >= 0)
                    {
                        balance -= item.ItemCost;
                        txtblckTerminal.Text = ($"You chose {item.Name}. It'll be {item.ItemCost}. Your balance is now: {balance}");
                        keyNum = "";
                        break;
                    }
                }
                else 
                { 
                    i++;
                }
            }

            foreach (var item in drinkItem)
            {
                if (num == item.ItemNumber)
                {
                    if (balance - item.ItemCost < 0)
                    {
                        txtblckTerminal.Text = ($"Sorry, you can't afford this item. Insert money into the machine to complete the purchase. Your current balance is: {balance}.");
                        keyNum = "";
                        break;
                    }
                    else if (balance - item.ItemCost >= 0)
                    {
                        balance -= item.ItemCost;
                        txtblckTerminal.Text = ($"You chose {item.Name}. It'll be {item.ItemCost}. Your balance is now: {balance}");
                        keyNum = "";
                        break;
                    }
                }
                else 
                {
                    i++;
                }
            }
            foreach (var item in snackItem)
            {
                if (num == item.ItemNumber)
                {
                    if (balance - item.ItemCost < 0)
                    {
                        txtblckTerminal.Text = ($"Sorry, you can't afford this item. Insert money into the machine to complete the purchase. Your current balance is: {balance}.");
                        keyNum = "";
                        break;
                    }
                    else if (balance - item.ItemCost >= 0)
                    {
                        balance -= item.ItemCost;
                        txtblckTerminal.Text = ($"You chose {item.Name}. It'll be {item.ItemCost}. Your balance is now: {balance}");
                        keyNum = "";
                        break;
                    }
                }
                else 
                {
                    i++;
                }
            }

            // Instead of having the message below printed 9 times, have some logic ensure that if the loop ever runs to completion without getting a match, display the message once:
            // if i == 9 in this case since we have 9 objects)
            if (i == foodItem.Length + snackItem.Length + drinkItem.Length)
            {
                txtblckTerminal.Text = ($"Sorry, no item matching number: '{num}' exists.");
                keyNum = "";
            }
        }        

        // Sets the balance - ensures balance cannot exceed 1000:
        public void setBalance()
        {
            if (num + balance > 1000) txtblckTerminal.Text = ($"Your balance cannot exceed 1000. Your current balance is: {balance}");
            else txtblckTerminal.Text = ($"The money has been inserted, your balance is now: {Convert.ToString(balance += num)}.");
        }
    }
    
    public class Items
    {
        public string? Name { get; set; }
        public int? ItemNumber { get; set; }
        public int? ItemCost { get; set; }

        public static int? balance = 0;
        public Items(string? name, int? itemNumber, int? itemCost)
        {
            Name = name;
            ItemNumber = itemNumber;
            ItemCost = itemCost;
        }
    }
    
    public class Foods : Items
    {
        public bool IsFood { get; set; }
        public Foods(string? name, int? itemNumber, int? itemCost, bool isFood) : base(name, itemNumber, itemCost)
        {
            IsFood = isFood;
        }
    }
    
    public class Snacks : Items
    {
        public bool IsSnack { get; set; }
        public Snacks(string? name, int? itemNumber, int? itemCost, bool isSnack) :
            base(name, itemNumber, itemCost)
        {
            IsSnack = isSnack;
        }
    }
    
    public class Drinks : Items
    {
        public bool IsDrink { get; set; }

        public Drinks(string? name, int? itemNumber, int? itemCost, bool isDrink) : base(name, itemNumber, itemCost)
        {
            IsDrink = isDrink;
        }
    }
}
