using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class Weapons : Items
    {
        public int _increasedDamage;
        static private List<Weapons> _weaponList = new List<Weapons>();
        
        public int IncreasedDamage { get => _increasedDamage; }

        static public List<Weapons> WeaponList { get => _weaponList; set => _weaponList = value;  }
    
        public Weapons(string name, int increasedDamage, int itemCost)
            : base (name, itemCost)
        {
            Name = name;
            _increasedDamage = increasedDamage;
            ItemCost = itemCost;
        }
        
    }
}
