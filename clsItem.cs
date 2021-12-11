namespace CS3280_Group_Project
{
    public class clsItem
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

        /// <summary>
        /// constructor for item with ID, name and price
        /// </summary>
        /// <param name="_itemID">Item ID</param>
        /// <param name="_name">Name</param>
        /// <param name="_price">Price</param>
        public clsItem (int _itemID, string _name, decimal _price)
        {
            itemID = _itemID;
            name = _name;
            price = _price;
        }
    }
}
