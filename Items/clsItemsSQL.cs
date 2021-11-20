using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;


namespace CS3280_Group_Project
{
    class clsItemsSQL
    {

        /// <summary>
        /// Default constructor for clsItemsSQL object
        /// </summary>
        public clsItemsSQL ()
        {

        }

        /// <summary>
        /// Gets a list of all items within the Items table
        /// </summary>
        /// <returns> List of items within the Items table </returns>
        public static DataSet GetItems ()
        {

            try
            {
                // SQL query to be passed into ExecuteSQLStatement
                string sSQL = "SELECT * FROM Items;";
                // List of items to be filled and returned
                List<clsItem> itemsList = new List<clsItem> ();
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess ();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem>
                DataSet ds = db.ExecuteSQLStatement (sSQL, ref iRets);

                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        public static void InsertItem (int itemID, string _name, decimal _price)
        {
            try
            {
                clsDataAccess db = new clsDataAccess ();
                string sSQL = "INSERT INTO Items (Item_ID, Item, Price) Values (" + itemID.ToString () + ", '" + _name.ToString () + "', " +
                    _price.ToString () + ");";

                db.ExecuteNonQuery (sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        public static void DeleteItem (int itemID)
        {
            try
            {
                clsDataAccess db = new clsDataAccess ();
                string sSQL = "DELETE FROM Items WHERE Item_ID = " + itemID.ToString () + ";";

                db.ExecuteNonQuery (sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        public static void EditItem (int itemID, string itemName, decimal itemPrice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess ();
                string sSQL = "UPDATE Items " +
                    " SET item = '" + itemName.ToString () + "'" +
                    " AND price = " + itemPrice.ToString () +
                    " WHERE Item_ID = " + itemID.ToString ();
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

    }
}
