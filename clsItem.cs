using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project
{
    class clsItem
    {
        private int itemID;

        private string name;

        private decimal price;

        public int ItemID { get => itemID; set => itemID = value; }

        public string Name { get => name; set => name = value; }

        public decimal Price { get => price; set => price = value; }
    }
}
