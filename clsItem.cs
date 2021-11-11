using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project
{
   public  class clsItem
    {
        /// <summary>
        /// private item ID variable
        /// </summary>
        private int itemID;

        /// <summary>
        /// private name variable
        /// </summary>
        private string name;

        /// <summary>
        /// private price variable
        /// </summary>
        private decimal price;

        /// <summary>
        /// public item ID with get and set
        /// </summary>
        public int ItemID { get => itemID; set => itemID = value; }

        /// <summary>
        /// public name with get and set
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// public price with get and set
        /// </summary>
        public decimal Price { get => price; set => price = value; }
    }
}
