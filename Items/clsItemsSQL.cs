/* Michael Voskanyan
 * File edited date: 11/20/2021
 * Filename: clsItemsSQL.cs
 * Description: 
 * This file contains the class clsItemsSQL, which has several member functions. Apart from the constructor,
 * this file contains the static functions GetItems, InsertItem, EditItem, and DeleteItem, which function
 * as their names suggest. GetItems returns a dataset to be parsed in the clsItemsLogic class. The dataset
 * contains the table pulled from the Items table in the database. InsertItem adds a new item to the database,
 * EditItem edits an existing item's name and price based off of the itemID provided as a parameter. The 
 * DeleteItem function deletes an item from the database using the itemID parameter as the way of locating the
 * item to be deleted from the database. Currently, there are two major issues with this class. First, InsertItem 
 * and DeleteItem both function at runtime, but I can't get the COMMIT command to work in the sSQL strings in both
 * methods, meaning that any changes to the database aren't actually permanent. The second major issue is that 
 * EditItems does not work at all. Despite a new item name, new item price, and item id being passed in, the 
 * method does not actually update the item. I'm not sure why it doesn't work, but I believe it has something to
 * do with the actual SQL in this class. Apart from the EditItems method, though, everything works on runtime.
 */ 
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

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet ds = db.ExecuteSQLStatement (sSQL, ref iRets);

                // DataSet returned, parsed into a list of clsItem objects inside the clsItemsLogic member function, also named GetItems.
                return ds;

            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method inserts a new item into the Items table in the database. 
        /// </summary>
        /// <param name="_name"> Name of the new item to be created in the table </param>
        /// <param name="_price"> Price of the new item to be created in the table </param>
        public static void InsertItem (string _name, decimal _price)
        {
            try
            {
                // clsDataAccess object created to access the member function ExecuteNonQuery
                clsDataAccess db = new clsDataAccess ();
                // String containing the SQL commands to be passed into the ExecuteNonQuery member function of clsDataAccess
                string sSQL = "INSERT INTO Items (Item, Price) Values ('" + _name.ToString () + "', " +
                    _price.ToString () + ");";

                // clsDataAccess member function ExecuteNonQuery called, passing in the sSQL string from above for the sql commands
                db.ExecuteNonQuery (sSQL);
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an itemID as a parameter, and deletes the item with that ID from the table.
        /// </summary>
        /// <param name="itemID"> the item ID of the item that is to be deleted </param>
        public static void DeleteItem (int itemID)
        {
            try
            {
                // clsDataAccess object created to access the non-static member function ExecuteNonQuery
                clsDataAccess db = new clsDataAccess ();
                // String containing the SQL for the ExecuteNonQuery member function of clsDataAccess
                string sSQL = "DELETE FROM Items WHERE Item_ID = " + itemID.ToString () + ";";

                // SQL code is passed into the method call as a parameter of the clsDataAccess member function ExecuteNonQuery
                db.ExecuteNonQuery (sSQL);
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Currently not functioning, this method is supposed to take an item id to reference 
        /// the item that the user wants to edit, as well as the updated item name and price,
        /// and change them in the database. I believe the reason this method does not function
        /// has something to do with the SQL code in the sSQL string, but I'm not sure as of
        /// right now. 
        /// </summary>
        /// <param name="itemID"> ID of the item to be updated </param>
        /// <param name="itemName"> New name of the selected item </param>
        /// <param name="itemPrice"> New price of the selected item </param>
        public static void EditItem (int itemID, string itemName, decimal itemPrice)
        {
            try
            {
                // cldDataAccess object created for access to the ExecuteNonQuery member function
                clsDataAccess db = new clsDataAccess ();
                // String containing the SQL code to be passed into the ExecuteNonQuery function
                string sSQL =   "UPDATE Items " +
                                "SET item = '" + itemName.ToString () + "' " +
                                "AND price = " + itemPrice.ToString () + " " + 
                                "WHERE Item_ID = " + itemID.ToString () + ";";

                // Function call for the clsDataAccess class' member function ExecuteNonQuery
                db.ExecuteNonQuery (sSQL);
            }
            catch (Exception ex) // Exception Handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

    }
}
