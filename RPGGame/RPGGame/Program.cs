namespace RPGGame
{
    class Program
    {
        static void Main(string[] args) {

            // Weapons
            Weapons weapon1 = new Weapons("Butterknife", 5, 20);
            Weapons weapon2 = new Weapons("Longsword", 30, 150);
            Weapons weapon3 = new Weapons("Battleaxe", 80, 400);

            // Armors
            Armor armor1 = new Armor("Soggy Toiletpaper", 15, 40);
            Armor armor2 = new Armor("T-shirt & Jeans", 100, 200);
            Armor armor3 = new Armor("Knight's Armor", 350, 600);

            GameSystem general = new GameSystem();

            Shop shop = new Shop();
            shop.WeaponsToList(weapon1);
            shop.WeaponsToList(weapon2);
            shop.WeaponsToList(weapon3);

            shop.ArmorToList(armor1);
            shop.ArmorToList(armor2);
            shop.ArmorToList(armor3);

            Console.WriteLine("Hello. Type your name:");

            string characterName = Console.ReadLine();
            if (characterName == "")
            {
                characterName = "player";
            }

            Console.WriteLine($"Greetings, {characterName}.");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            // outer gameloop
            while (general.GameStateOn)
            {
                Player player = new Player(characterName);
                Console.Clear();
                general.GameScreen(player);
                Console.WriteLine("SHOP <--- Input 'S'           Input 'Q' to quit             Input 'E' ---> BATTLEGROUNDS");
                //GameSystem.GetKey();
                switch (general.GetKey())
                {
                    case "Q":
                        string userConfirm = GameSystem.YesNo();
                        if (userConfirm == "yes")
                        {
                            general.GameStateOn = false;
                            Console.WriteLine("Sad to see you go");
                            Console.ReadLine();
                            continue;
                        }
                        if (userConfirm == "no")
                        {
                            break;
                        }
                        break;

                    case "E":
                        // New boss and gamesystem objects, ensuring things like HP, money earned and gamemodifier are reset when player enters combat
                        Boss boss = new Boss();
                        general = new GameSystem();
                        GameSystem.CombatLog = new List<string>();
                        Console.Clear();
                        general.FightScreen(player, boss);
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();

                        while (general.BattleStateOn)
                        {

                            int bossAttack = 0;

                            Console.Clear();

                            boss.GetBossAttack();
                            

                            Console.Clear();
                            general.FightScreen(player, boss);

                            switch (boss.AttackSelector)
                            {
                                case 1:
                                    bossAttack = boss.LightAttack();
                                    break;

                                case 2:
                                    bossAttack = boss.HeavyAttack();
                                    break;
                            }

                            switch(general.GetKey())
                            {
                                case "L":
                                    boss.TakeDamage(player.LightAttack());
                                    general.DamageDone += player.LightAttack();
                                    player.TakeDamage(bossAttack);
                                    break;

                                case "H":
                                    boss.TakeDamage(player.HeavyAttack());
                                    general.DamageDone += player.HeavyAttack();
                                    player.TakeDamage(bossAttack);
                                    break;

                                case "B":
                                    player.TakeDamage(player.Block(bossAttack));
                                    break;

                                case "F":

                                    GameSystem.AddToCombatLog("");
                                    GameSystem.AddToCombatLog($"You tugged and ran. . . .");
                                    Console.Clear();
                                    general.FightScreen(player, boss);
                                    Thread.Sleep(2000);
                                    
                                    
                                    GameSystem.AddToCombatLog($" but you earned {general.Money * general.CombatModifier} gold!");
                                    Player.Money += general.Money * general.CombatModifier;
                                    GameSystem.AddToCombatLog($"{ Player.Money}");
                                    
                                    general.BattleStateOn = false;

                                    Console.Clear();
                                    general.FightScreen(player, boss);
                                    Console.ReadLine();
                                    continue;

                                default:
                                    player.TakeDamage(bossAttack);
                                    GameSystem.AddToCombatLog("Not a correct input.");
                                    break;
                            }

                            if (player.IsDead())
                            {
                                GameSystem.AddToCombatLog("");
                                GameSystem.AddToCombatLog("You died and lost all your gold.");
                                Player.Money = 0;

                                Console.Clear();
                                general.FightScreen(player, boss);
                                Console.ReadLine();
                                break;
                            }
                            if (boss.IsDead())
                            {
                                GameSystem.AddToCombatLog("");
                                GameSystem.AddToCombatLog("You won! Have all the gold!");
                                Player.Money = 100000;

                                Console.Clear();
                                general.FightScreen(player, boss);
                                Console.ReadLine();
                                break;
                            }

                            GameSystem.AddToCombatLog("");
                            general.RoundsSurvived += 1;
                            general.MoneyGained();
                            general.CalculateCombatModifier();
                        }
                        break;

                    case "S":
                        while (general.ShopStateOn)
                        {
                            Console.Clear();
                            shop.ShopScreen();
                            Console.ReadLine();
                        }
                        break;
                }
            }            
        }
    }
}