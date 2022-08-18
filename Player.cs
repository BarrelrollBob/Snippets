using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class Player
    {
        private string? _name;
        private int _healthPoints;
        private int _damage;
        static private double _money;

        private string[] _toolBelt = new string[3];

        private Dictionary<string, Items> _equipment = new Dictionary<string, Items>()
        {
            {"Weapon", null },
            {"Armor", null }
        };

        public string Name { get => _name; set => _name = value; }        
        public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        public int Damage { get => _damage; set => _damage = value; }
        static public double Money { get => _money; set => _money = value; }
        public string[] ToolBelt { get => _toolBelt; }
        public Dictionary<string, Items> Equipment { get => _equipment; set => _equipment = value; }

        public Player(string? name = "player")
        {
            Name = name;
            HealthPoints = 100;
            Damage = 10;
        }
        public bool IsDead()
        {
            if (_healthPoints <= 0) return true;
            else return false;
        }

        public int Block(int dmg)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 4);

            if (randomNumber >= 2)
            {
                dmg /= 2;
                GameSystem.AddToCombatLog($"You blocked the attack and only took partial damage.");
            }
            if (randomNumber < 2)
            {
                dmg -= dmg;
                GameSystem.AddToCombatLog("You completely blocked the attack!");
            }
            return dmg;
        }    

        public void AddItem(string item)
        {
            for (int i = 0; i < _toolBelt.Length; i++)
            {
                if (_toolBelt[i] == string.Empty)
                {
                    _toolBelt[i] = item;
                    break;
                }
            }
            Console.WriteLine("Your toolbelt is full.");
        }

        public void ReplaceItem(string item, int num)
        {
            string userConfirm;
            switch (num)
            {
                case 1:
                    Console.WriteLine($"Are you sure you want to replace {_toolBelt[0]}");

                    userConfirm = GameSystem.YesNo();

                    if (userConfirm == "yes")
                    {
                        _toolBelt[0] = item;
                        break;
                    }
                    if (userConfirm == "no")
                    {
                        Console.WriteLine("Would you like to select a different item to replace?");

                        userConfirm = GameSystem.YesNo();

                        if (userConfirm == "yes")
                        {
                            Console.WriteLine("Which item would you like to replace?");
                            num = Convert.ToInt32(Console.ReadLine());
                            ReplaceItem(item, num);
                        }
                        if (userConfirm == "no")
                        {
                            Console.WriteLine("Item has been discarded");
                            break;
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine($"Are you sure you want to replace {_toolBelt[1]}");

                    userConfirm = GameSystem.YesNo();

                    if (userConfirm == "yes")
                    {
                        _toolBelt[1] = item;
                        break;
                    }
                    if (userConfirm == "no")
                    {
                        Console.WriteLine("Would you like to select a different item to replace?");

                        userConfirm = GameSystem.YesNo();

                        if (userConfirm == "yes")
                        {
                            Console.WriteLine("Which item would you like to replace?");
                            num = Convert.ToInt32(Console.ReadLine());
                            ReplaceItem(item, num);
                        }
                        if (userConfirm == "no")
                        {
                            Console.WriteLine("Item has been discarded");
                            break;
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine($"Are you sure you want to replace {_toolBelt[2]}");

                    userConfirm = GameSystem.YesNo();

                    if (userConfirm == "yes")
                    {
                        _toolBelt[2] = item;
                        break;
                    }
                    if (userConfirm == "no")
                    {
                        Console.WriteLine("Would you like to select a different item to replace?");

                        userConfirm = GameSystem.YesNo();

                        if (userConfirm == "yes")
                        {
                            Console.WriteLine("Which item would you like to replace?");
                            num = Convert.ToInt32(Console.ReadLine());
                            ReplaceItem(item, num);
                        }
                        if (userConfirm == "no")
                        {
                            Console.WriteLine("Item has been discarded");
                            break;
                        }
                    }
                    break;
            }
        }

        public bool InventoryFull()
        {

            // check all 3 indexes in _toolBelt if they're empty or not
            for (int i = 0; i < _toolBelt.Length; i++)
            {
                if (_toolBelt[i] == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Light attack
        public int LightAttack()
        {
            // 80% chance to hit

            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 6);
            if (randomNumber >= 2)
            {
                return Damage;
            }
            if (randomNumber < 2)
            {
                GameSystem.AddToCombatLog("You missed the attack!");
            }
            return Damage;
        }

        public int HeavyAttack()
        {
            // Double damage but 50% chance to hit

            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 2);
            switch (randomNumber)
            {
                case 1:
                    GameSystem.AddToCombatLog("You missed the attack!");
                    break;
                case 2:
                    return Damage * 2;
            }
            return Damage;
        }

        //TakeDamage method
        public void TakeDamage(int damage)
        {
            _healthPoints -= damage;
        }

        //Gain gold method
        public static void ReceiveGold(double moneyAmount)
        {
            _money += moneyAmount;
        }
    }        
}


