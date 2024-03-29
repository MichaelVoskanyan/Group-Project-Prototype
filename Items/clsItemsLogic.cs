﻿/* Michael Voskanyan
 * File edited date: 11/20/2021
 * Filename: clsItemsLogic.cs
 * Description:
 * This is the class file for clsItemsLogic. It contains the default constructor for the 
 * class, as well as the GetItems method, InsertItem, DeleteItem, and EditItem.
 * These methods function as their names suggest, where GetItems returns a list of clsItem 
 * objects, InsertItem inserts a new item into the database, DeleteItem removes an item 
 * from the database, and EditItem updates the item name, price, or both in the datbase.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CS3280_Group_Project
{
    class clsItemsLogic
    {
        /// <summary>
        /// Default constructor for clsItemsLogic class
        /// </summary>
        public clsItemsLogic()
        {

        }

        /// <summary>
        /// The GetItems method returns a List of clsItem Objects when called. It 
        /// creates a new list of clsItem objects and a DataSet. The Dataset contains
        /// the table pulled from the database by the GetItems () method in the items 
        /// SQL file. 
        /// </summary>
        /// <returns> A list of every item inside the Item table as a List<clsItem> </returns>
        public static List<clsItem> GetItems()
        {
            try
            {
                // List of clsItem objects to contain the list pulled from the database
                List<clsItem> itemsList = new List<clsItem>();
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet ds = db.ExecuteSQLStatement(clsItemsSQL.GetItems(), ref iRets);


                // For-loop that pulls the data from the dataset into a clsItem object, and then adds the object to a list of clsItem objects
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    // Passes the data from each column into a new clsItem object
                    clsItem tempItem = new clsItem(int.Parse(ds.Tables[0].Rows[i][0].ToString()),
                        ds.Tables[0].Rows[i][1].ToString(), decimal.Parse(ds.Tables[0].Rows[i][2].ToString()));

                    // Adds the clsItem to a list of clsItems (each item is accessed from the dataset row by row, indexed by i in the for-loop_
                    itemsList.Add(tempItem);
                }

                // Returns the list of clsItem objects
                return itemsList;
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method handles the insertion of new items into the Item table within the database. 
        /// When called the method requires two parameters, the new items name and the new items 
        /// price. Input validation is handled within the wndItems.xaml.cs file, for the sake of 
        /// easier access to the warning label within the windows UI. The method calls the InsertItem
        /// method found in the clsItemsSQL class, which handles the actual SQL portion of inserting
        /// a new item.
        /// </summary>
        /// <param name="itemName">Item Name</param>
        /// <param name="itemPrice">Item Price</param>
        public static void InsertItem(string itemName, decimal itemPrice)
        {
            try
            {
                // clsDataAccess object created to access the member function ExecuteNonQuery
                clsDataAccess db = new clsDataAccess();
                // Calls the static member InsertItem from the clsItemsSQL class
                clsItemsSQL.InsertItem(itemName, itemPrice);



                // clsDataAccess member function ExecuteNonQuery called, passing in the sSQL string from above for the sql commands
                db.ExecuteNonQuery(clsItemsSQL.InsertItem(itemName, itemPrice));
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes the item that the user selected from the datagrid in the Items Window UI. 
        /// </summary>
        /// <param name="itemID"> Item id of the selected item from the datagrid from the Items Window UI </param>
        public static void DeleteItem(int itemID)
        {
            try
            {
                // clsDataAccess object created to access the non-static member function ExecuteNonQuery
                clsDataAccess db = new clsDataAccess();

                // SQL code is passed into the method call as a parameter of the clsDataAccess member function ExecuteNonQuery
                db.ExecuteNonQuery(clsItemsSQL.DeleteItem(itemID));
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Currently nonfunctional, but this method is supposed to call the EditItem member from the clsItemsSQL 
        /// class, passing in the parameteres listed below. I believe the issue is something to do with the actual
        /// SQL inside the clsItemsSQL member function, but I am not sure as of right now. What it's supposed to do
        /// though is take the input from the textboxes (which are passed in as parameters) as well as the item id
        /// from the selection made in the datagrid on the Items window UI and update the name and/or the price from 
        /// the textboxes in the window UI. The input validation has not been coded in yet since the method is non-
        /// functional, but there will be input validation coded into the final submission.
        /// </summary>
        /// <param name="itemID"> Selected item id from the datagrid. This value serves to locate the item to be edited </param>
        /// <param name="itemName"> The new name of the item, pulled from the item name textbox on the window's UI </param>
        /// <param name="itemPrice"> The updated price of the item, pulled from the item price textbox on the window's UI </param>
        public static void EditItem(int itemID, string itemName, decimal itemPrice)
        {
            try
            {
                // cldDataAccess object created for access to the ExecuteNonQuery member function
                clsDataAccess db = new clsDataAccess();

                    // Function call for the clsDataAccess class' member function ExecuteNonQuery
                 db.ExecuteNonQuery(clsItemsSQL.EditItem(itemID, itemName, itemPrice));
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
