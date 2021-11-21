/* Michael Voskanyan
 * File edited date: 11/20/2021
 * Filename: clsItemsSQL.cs
 * Description: 
 * This is the class file for clsItemsSQL. It contains the default constructor, as well as four methods;
 * GetItems, InsertItem, DeleteItem, and EditItem. These four functions return string containing the SQL
 * code that needs to be run in the clsItemsLogic class, by the clsDataAccess member functions ExecuteNonQuery
 * or ExecuteSQLStatement. 
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
        /// Returns the SQL code for getting items from the Items table, to be used in the clsItemsLogic member function GetItems()
        /// </summary>
        /// <returns> SQL code in the form of a string to be used in the ExecuteSQLStatement member function of clsDataAccess </returns>
        public static String GetItems ()
        {

            try
            {
                // SQL query to be passed into ExecuteSQLStatement
                string sSQL = "SELECT * FROM Items;";

                return sSQL;
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method inserts the new item name and price into the SQL code stored in the string sSQL
        /// </summary>
        /// <param name="_name"> Name of the new item to be created in the table </param>
        /// <param name="_price"> Price of the new item to be created in the table </param>
        /// <returns> String containing the SQL code to be run in the clsDataAccess member function ExecuteNonQuery </returns>
        public static string InsertItem (string _name, decimal _price)
        {
            try
            {
                // String containing the SQL commands to be passed into the ExecuteNonQuery member function of clsDataAccess
                string sSQL = "INSERT INTO Items (Item, Price) Values ('" + _name.ToString () + "', " +
                    _price.ToString () + ");";

                return sSQL;
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an itemID as a parameter and inserts it into the SQL code to be
        /// run by the clsDataAccess member function ExecuteNonQuery
        /// </summary>
        /// <param name="itemID"> the item ID of the item that is to be deleted </param>
        /// <returns> String containing all the SQL code to delete the item with the itemID = to the param above </returns>
        public static string DeleteItem (int itemID)
        {
            try
            {
                
                // String containing the SQL for the ExecuteNonQuery member function of clsDataAccess
                string sSQL = "DELETE FROM Items WHERE Item_ID = " + itemID.ToString () + ";";

                return sSQL;
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Currently not functioning, this method takes the parameters listed below and 
        /// inserts them into the string containing the SQL code. 
        /// right now. 
        /// </summary>
        /// <param name="itemID"> ID of the item to be updated </param>
        /// <param name="itemName"> New name of the selected item </param>
        /// <param name="itemPrice"> New price of the selected item </param>
        /// <returns> String containing the SQL code to be run by the clsDataAccess ExecuteNonQuery function </returns>
        public static string EditItem (int itemID, string itemName, decimal itemPrice)
        {
            try
            { 
                // String containing the SQL code to be passed into the ExecuteNonQuery function
                string sSQL =   "UPDATE Items " +
                                "SET item = '" + itemName.ToString () + "' " +
                                "AND price = " + itemPrice.ToString () + " " + 
                                "WHERE Item_ID = " + itemID.ToString () + ";";

                return sSQL;
            }
            catch (Exception ex) // Exception Handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

    }
}
