using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class Shop
    {
        public void ShopScreen()
        {
            Console.WriteLine("The Shop");
            Console.WriteLine();
            Console.WriteLine("List of weapons:");

            foreach (var weapon in Weapons.WeaponList)
            {
                Console.WriteLine($"{weapon.Name}:");
                Console.WriteLine($"- Increases damage by: {weapon._increasedDamage}:");
                Console.WriteLine($"- Cost: {weapon.ItemCost}:");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("List of armors:");
                        
            foreach(var armor in Armor.ArmorList)
            {
                Console.WriteLine($"{armor.Name}:");
                Console.WriteLine($"- Increases health by: {armor.IncreasedHealthPoints}");
                Console.WriteLine($"- Cost: {armor.ItemCost}");
                Console.WriteLine();
            }
        }
        // Generate two random numbers between 1, 6. -1. Target index [randomNumber] to choose which items to put into shop list

        public void WeaponsToList(Weapons weapon)
        {
            Weapons.WeaponList.Add(weapon);
        }
        public void ArmorToList(Armor armor)
        {
            Armor.ArmorList.Add(armor);
        }

        // buyItem {}
        public void BuyItem()
        {

        }
        

    }    
}


// Blade of Thousand Truths -- type in 'adad21wsad' to receive. Does 10000 damage a hit
// Garments of Sun Tzu -- type in 'wsws12adad' to receive. Increases HP by 50000.
// If you have both the Blade of Thousand Truths & Garments of Sun Tzu, upon entering the battleground run a special event.