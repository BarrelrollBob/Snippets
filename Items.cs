using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    internal class Items
    {
        private string _name;
        private int _itemCost;

        public string Name { get => _name; set => _name = value; }
        public int ItemCost { get => _itemCost; set => _itemCost = value; }

        public Items(string name, int itemCost)
        {
            Name = name;
            ItemCost = itemCost;
        }
    }
}
