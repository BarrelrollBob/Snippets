using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class GameSystem
    {
        private bool _gameStateOn = true;
        private bool _battleStateOn = true;
        private bool _shopStateOn = true;
        private double _money;
        private double _combatModifier;
        private int _roundsSurvived;
        private int _damageDone;
        static private List<string> _combatLog = new List<string>();

        public void FightScreen(Player hero, Boss bigBad)
        {
            Console.WriteLine("Controls: input 'L' to hit the boss with a Light Attack, 'H' to strike the boss with a Heavy Attack, 'B' to block incoming damage and 'F' to flee combat.");
            Console.WriteLine();
            Console.WriteLine($"Damage done: {_damageDone}\nRounds survived: {_roundsSurvived}");
            Console.WriteLine();
            Console.WriteLine($"Potential money gain: {Money}");
            Console.WriteLine($"Combat modifier: {_combatModifier}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{hero.Name}'s health: {hero.HealthPoints}          {bigBad.Name}'s health: {bigBad.HealthPoints}");
            Console.WriteLine($"{hero.Name}'s damage: {hero.Damage}          {bigBad.Name}'s damage: {bigBad.Damage}");
            Console.WriteLine();
            Console.WriteLine("Items");
            Console.WriteLine($"[{hero.ToolBelt[0]}] [{hero.ToolBelt[1]}] [{hero.ToolBelt[2]}]");
            PrintCombatLog();
        }

        public void GameScreen(Player hero)
        {
            Console.WriteLine($"Name: {hero.Name}");
            Console.WriteLine($"Money: {Player.Money}");
            Console.WriteLine();
            Console.WriteLine($"Health: {hero.HealthPoints}");
            Console.WriteLine($"Damage: {hero.Damage}");
            Console.WriteLine($"Equipment:\n{hero.Equipment["Weapon"]}\n{hero.Equipment["Armor"]}");
        }

        public bool GameStateOn { get => _gameStateOn; set => _gameStateOn = value; }
        public bool BattleStateOn { get => _battleStateOn; set => _battleStateOn = value; }
        public bool ShopStateOn { get => _shopStateOn; set => _shopStateOn = value; }
        public int RoundsSurvived { get => _roundsSurvived; set => _roundsSurvived = value; }
        public int DamageDone { get => _damageDone; set => _damageDone = value; }
        public double Money { get => _money; set => _money = value; }
        public double CombatModifier { get => _combatModifier; }

        static public List<string> CombatLog{ get => _combatLog; set => _combatLog = value; }


        static public void AddToCombatLog(string text)
        {
            _combatLog.Add(text);
        }
        public void PrintCombatLog()
        {
            foreach (var text in _combatLog)
            {
                Console.WriteLine(text);
            }
        }

        public void MoneyGained()
        {
            Random rnd = new Random();
            int randomNumber;
            int moneyAmount;
            // 33% chance to receive a random amount of money between 1 and 10 gold.
            randomNumber = rnd.Next(1, 4);
            moneyAmount = rnd.Next(1, 11);

            if (randomNumber < 3)
            {
                Money += moneyAmount;
            }

        }
        public double CalculateCombatModifier()
        {
            return _combatModifier += (_roundsSurvived * 0.20) + (_damageDone * 0.10);
        }

        public static string YesNo()
        {
            Console.WriteLine("Are you sure? Type 'yes' or 'no'");
            string answer = Console.ReadLine();
            answer = answer.ToLower(); 
            while (answer != "yes" & answer != "no")
            {
                Console.WriteLine("That's not valid input - please try again.");
                answer = Console.ReadLine();
            }
            return answer;
        }

        public string GetKey()
        {
            string key = Console.ReadLine().ToUpper();
            switch (key)
            {
                case "E":
                    return key;
                case "S":
                    return key;
                case "L":
                    return key;
                case "H":
                    return key;
                case "B":
                    return key;
                case "F":
                    return key;
                case "Q":
                    return key;
                default:
                    return key;
            }
        }
    }
}
