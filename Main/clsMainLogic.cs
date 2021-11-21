using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
        /// method to get order dataset and create list of orders and return that list of orders
        /// </summary>
        /// <returns>List of orders</returns>
        public static List<clsOrder> GetOrders ()
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet orders = db.ExecuteSQLStatement(clsMainSQL.GetOrders(), ref iRets);

                List<clsOrder> lstOrders = new List<clsOrder> ();
                for (int i = 0; i < orders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder (int.Parse (orders.Tables[0].Rows[i][0].ToString ()),
                        DateTime.Parse (orders.Tables[0].Rows[i][1].ToString ()),
                        decimal.Parse (orders.Tables[0].Rows[i].ItemArray[2].ToString ()));
                    lstOrders.Add (newOrder);
                }
                return lstOrders;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

    }
}
