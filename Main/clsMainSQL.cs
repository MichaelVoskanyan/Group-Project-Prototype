using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project {
	class clsMainSQL {

        /// <summary>
        /// method to get all items
        /// </summary>
        /// <returns></returns>
        public static DataSet GetItems()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                //Create a DataSet to hold the data
                DataSet ds = new DataSet();

                //Number of return values
                int iRet = 0;

                //Get all the values from the Items
                ds = db.ExecuteSQLStatement(
                   "SELECT Items.* FROM Items"
                    // "SELECT P.* FROM Passenger AS P"
                    , ref iRet);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to get all order data
        /// </summary>
        /// <returns></returns>
        public static DataSet GetOrders()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                //Create a DataSet to hold the data
                DataSet ds = new DataSet();

                //Number of return values
                int iRet = 0;

                //Get all the Order info
                ds = db.ExecuteSQLStatement(
                    "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                   " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                   "  GROUP BY Orders.Order_ID, Orders.Order_Date"
                    // "SELECT P.* FROM Passenger AS P"
                    , ref iRet);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// get all ordered items for an order
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static DataSet GetOrderItems(int OrderID)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                //Create a DataSet to hold the data
                DataSet ds = new DataSet();

                //Number of return values
                int iRet = 0;

                //Get all the order items for an order ID
                ds = db.ExecuteSQLStatement(
                    "SELECT Order_Items.Order_ID, Items.Item_ID, Items.Item, Items.Price FROM Items "+
                    "INNER JOIN Order_Items ON Items.Item_ID = Order_Items.Item_ID WHERE Items.Item_ID="+ OrderID
                    // "SELECT P.* FROM Passenger AS P"
                    , ref iRet);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// delete all items for an order. used to clean and reload an order for editing
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static DataSet DeleteAllOrderItems(int OrderID)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                //Create a DataSet to hold the data
                DataSet ds = new DataSet();

                //Number of return values
                int iRet = 0;

                //delete all items for an order
                ds = db.ExecuteSQLStatement(
                    "DELETE * FROM Order_Items WHERE Order_Items.Order_ID=" + OrderID
                    // "SELECT P.* FROM Passenger AS P"
                    , ref iRet);

                return ds;
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
        public static DataSet InsertOrderItem(int OrderID, int ItemID)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                //Create a DataSet to hold the data
                DataSet ds = new DataSet();

                //Number of return values
                int iRet = 0;

                //Get all the order items for an order ID
                ds = db.ExecuteSQLStatement(
                    "INSERT INTO Order_Items ( Order_ID, Item_ID ) SELECT "+ OrderID + " AS Expr1, "+ItemID+" AS Expr2"
                    // "SELECT P.* FROM Passenger AS P"
                    , ref iRet);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
