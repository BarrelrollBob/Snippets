using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Items
    {
        public string? Name { get; set; }
        public int? ItemNumber { get; set; }

        public int? ItemCost { get; set; } 
        public Items (string? name, int? itemNumber, int? itemCost)
        {
            Name = name;
            ItemNumber = itemNumber;
            ItemCost = itemCost;
        }  
    }
}
