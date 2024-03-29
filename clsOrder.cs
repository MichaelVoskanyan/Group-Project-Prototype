﻿using System;

namespace CS3280_Group_Project
{
    public class clsOrder
    {
        /// <summary>
        /// private order ID
        /// </summary>
        private int orderID;

        /// <summary>
        /// private order date
        /// </summary>
        private DateTime orderdate;

        /// <summary>
        /// private order total
        /// </summary>
        private decimal orderTotal;

        /// <summary>
        /// private list of items ordered
        /// </summary>
        /// private List<clsItem> items;

        /// <summary>
        /// public order ID with get and set
        /// </summary>
        public int OrderID { get => orderID; set => orderID = value; }

        /// <summary>
        /// public order date with get and set
        /// </summary>
        public DateTime OrderDate { get => orderdate; set => orderdate = value; }

        /// <summary>
        /// public order total with get and set
        /// </summary>
        public decimal OrderTotal { get => orderTotal; set => orderTotal = value; }

        /// <summary>
        /// constructor for Order with ID, Date and Total
        /// </summary>
        /// <param name="ID">Order ID</param>
        /// <param name="orDate">Order Date</param>
        /// <param name="Total">Total</param>
        public clsOrder (int ID, DateTime orDate, decimal Total)
        {
            orderID = ID;
            orderdate = orDate;
            orderTotal = Total;
        }
    }
}
