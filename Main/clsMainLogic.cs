using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows;

namespace CS3280_Group_Project
{
    /// <summary>
    /// logic for main window
    /// </summary>
    class clsMainLogic
    {
        /// <summary>
        /// class to hold data for the current selected order
        /// </summary>
        public static clsOrder currentOrder;

        /// <summary>
        /// field to hold data for the current selected item on the main form
        /// </summary>
        public static clsItem SelectedItem;

        /// <summary>
        /// field to hold list of data for the items in a order
        /// </summary>
        public static List<clsItem> OrderItems;

        /// <summary>
        /// boolean to check if app is currently edting an order
        /// </summary>
        public static bool isEditing;

        /// <summary>
        /// boolean to check if app is currenting loading a new item
        /// </summary>
        public static bool isloadingNew;

        /// <summary>
        /// method to get order dataset and create list of orders and return that list of orders
        /// </summary>
        /// <returns>List of orders</returns>
        public static List<clsOrder> GetOrders()
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet orders = db.ExecuteSQLStatement(clsMainSQL.GetOrders(), ref iRets);

                List<clsOrder> lstOrders = new List<clsOrder>();
                for (int i = 0; i < orders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(orders.Tables[0].Rows[i][0].ToString()),
                        DateTime.Parse(orders.Tables[0].Rows[i][1].ToString()),
                        decimal.Parse(orders.Tables[0].Rows[i].ItemArray[2].ToString()));
                    lstOrders.Add(newOrder);
                }
                return lstOrders;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static List<clsItem> GetOrderItems(int selectedOrder)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet orders = db.ExecuteSQLStatement(clsMainSQL.GetOrderItems(selectedOrder), ref iRets);

                List<clsItem> listItems = new List<clsItem>();
                for (int i = 0; i < orders.Tables[0].Rows.Count; i++)
                {
                    clsItem newItem = new clsItem(int.Parse(orders.Tables[0].Rows[i][0].ToString()),
                        orders.Tables[0].Rows[i][1].ToString(),
                        decimal.Parse(orders.Tables[0].Rows[i].ItemArray[2].ToString()));
                    listItems.Add(newItem);
                }
                return listItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to get all items from the databse
        /// </summary>
        /// <returns></returns>
        public static List<clsItem> GetItems()
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet orders = db.ExecuteSQLStatement(clsMainSQL.GetItems(), ref iRets);

                List<clsItem> listItems = new List<clsItem>();

                for (int i = 0; i < orders.Tables[0].Rows.Count; i++)
                {
                    clsItem newItem = new clsItem(int.Parse(orders.Tables[0].Rows[i][0].ToString()),
                        orders.Tables[0].Rows[i][1].ToString(),
                        decimal.Parse(orders.Tables[0].Rows[i].ItemArray[2].ToString()));
                    listItems.Add(newItem);
                }
                return listItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// update all ordered items for an order. first all previously listed order items are removed and new items are inserted
        /// </summary>
        /// <param name="orderID">Order ID</param>
        public static void UpdateOrderItems(int orderID)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;
                //clear existing items
                db.ExecuteNonQuery(clsMainSQL.DeleteAllOrderItems(orderID));

                //load new items
                foreach (clsItem I in OrderItems)
                {
                    db.ExecuteNonQuery(clsMainSQL.InsertOrderItem(orderID, I.ItemID));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
