using System;
using System.Data;
using System.Reflection;

namespace CS3280_Group_Project
{
    class clsMainSQL
    {

        /// <summary>
        /// method to get all items
        /// </summary>
        /// <returns></returns>
        public static string GetItems ()
        {
            try
            {
                string sql =
                   "SELECT Items.* FROM Items";
                    // "SELECT P.* FROM Passenger AS P"
           

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to get all order data sql
        /// </summary>
        /// <returns></returns>
        public static string GetOrders ()
        {
            try
            {
                string sql =
                    "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                   " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                   "  GROUP BY Orders.Order_ID, Orders.Order_Date";
                    // "SELECT P.* FROM Passenger AS P"
                 

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// get all ordered items for an order
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static string GetOrderItems (int OrderID)
        {
            try
            {
                string sql =
                         "SELECT Order_Items.Order_ID, Items.Item_ID, Items.Item, Items.Price FROM Items " +
                         "INNER JOIN Order_Items ON Items.Item_ID = Order_Items.Item_ID WHERE Items.Item_ID=" + OrderID.ToString();
                    // "SELECT P.* FROM Passenger AS P"
                 
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// delete all items for an order. used to clean and reload an order for editing
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static string DeleteAllOrderItems (int OrderID)
        {
            try
            {
                string sql =
                    "DELETE * FROM Order_Items WHERE Order_Items.Order_ID=" + OrderID.ToString()
                   // "SELECT P.* FROM Passenger AS P"
                   ;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        public static string DeleteOrder(int OrderID)
        {
            try
            {
                string sql =
                    "DELETE * FROM Orders WHERE Orders.Order_ID=" + OrderID.ToString()
                   // "SELECT P.* FROM Passenger AS P"
                   ;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to insert a new order item to an order. 
        /// </summary>
        /// <param name="OrderID">order id</param>
        /// <param name="ItemID">item id</param>
        /// <returns></returns>
        public static string InsertOrderItem (int OrderID, int ItemID)
        {
            try
            {

                //Get all the order items for an order ID
                string sql =
                    "INSERT INTO Order_Items ( Order_ID, Item_ID ) SELECT " + OrderID.ToString() + " AS Expr1, " + ItemID.ToString() + " AS Expr2";
                    // "SELECT P.* FROM Passenger AS P"
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to insert new order
        /// </summary>
        /// <param name="OrderDate"> Order Date </param>
        /// <returns></returns>
        public static string InsertOrder(DateTime OrderDate)
        {
            try
            {

                //Get all the order items for an order ID
                string sql =
                    "INSERT INTO Orders ( Order_Date ) Values (" + OrderDate + ")";
                    // "SELECT P.* FROM Passenger AS P"
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
