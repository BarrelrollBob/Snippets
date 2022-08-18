using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class Armor : Items
    {
        private int _increasedHealthPoints;
        static private List<Armor> _armorList = new List<Armor>();

        public int IncreasedHealthPoints { get => _increasedHealthPoints; }
        static public List<Armor> ArmorList { get => _armorList; set => _armorList = value; }

        public Armor(string name, int increasedHealthPoints, int itemCost)
            : base (name, itemCost)
        {
            base.Name = name;
            _increasedHealthPoints = increasedHealthPoints;
            base.ItemCost = itemCost;
        }
    }
}
