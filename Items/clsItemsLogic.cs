/* Michael Voskanyan
 * File edited date: 11/20/2021
 * Filename: clsItemsLogic.cs
 * Description:
 * This is the class file for clsItemsLogic. It contains the default constructor for the 
 * class, as well as the GetItems method, InsertItem, IncItemID, DeleteItem, and EditItem.
 * These methods function as their names suggest, where GetItems returns a list of clsItem 
 * objects, InsertItem inserts a new item into the database, DeleteItem removes an item 
 * from the database, and EditItem updates the item name, price, or both in the datbase.
 * Currently, any item inserted or deleted does not actually save inside the database, as the
 * SQL function "COMMIT" does not work for a reason not obvious to me. As such, any items added
 * or deleted from the database only appear at runtime, and when the program is restarted, the
 * changes do not carry over. The EditItem method also does not work presently. I believe this
 * is an issue with the actual SQL found in the clsItemsSQL class, but the item does not actually
 * change when the Edit Item button is clicked, with or without valid user input. 
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
        public clsItemsLogic ()
        {

        }

        /// <summary>
        /// The GetItems method returns a List of clsItem Objects when called. It 
        /// creates a new list of clsItem objects and a DataSet. The Dataset contains
        /// the table pulled from the database by the GetItems () method in the items 
        /// SQL file. 
        /// </summary>
        /// <returns> A list of every item inside the Item table as a List<clsItem> </returns>
        public static List<clsItem> GetItems ()
        {
            try
            {
                // List of clsItem objects to contain the list pulled from the database
                List<clsItem> itemsList = new List<clsItem> ();
                // Dataset to contain the table pulled by the GetItems () method in the clsItemSQL class
                DataSet ds = clsItemsSQL.GetItems ();

                // For-loop that pulls the data from the dataset into a clsItem object, and then adds the object to a list of clsItem objects
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    // Passes the data from each column into a new clsItem object
                    clsItem tempItem = new clsItem (int.Parse (ds.Tables[0].Rows[i][0].ToString ()),
                        ds.Tables[0].Rows[i][1].ToString (), decimal.Parse (ds.Tables[0].Rows[i][2].ToString ()));

                    // Adds the clsItem to a list of clsItems (each item is accessed from the dataset row by row, indexed by i in the for-loop_
                    itemsList.Add (tempItem);
                }

                // Returns the list of clsItem objects
                return itemsList;
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
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
        /// <param name="itemName"></param>
        /// <param name="itemPrice"></param>
        public static void InsertItem (string itemName, decimal itemPrice)
        {
            try
            {
                //clsItemsSQL.InsertItem (IncItemID (GetItems ()), itemName, itemPrice);

                // Calls the static member InsertItem from the clsItemsSQL class
                clsItemsSQL.InsertItem (itemName, itemPrice);
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This function is now irrelevant, but I've left it in here for the time being because of 
        /// conflicts that will occur with a new push to the GIT repository. It's intended function 
        /// was to increment the item id, since I was having some issues with the AUTO_INCREMENT in 
        /// SQL. The issues have since been resolved, and as such this method is no longer relevant. 
        /// <param name="items"> List of clsItem objects, passed in to find the largest item ID from the list </param>
        /// <returns> New integer for the item ID, incremented by one from the largest item id that exists within the Item table </returns>
        public static int IncItemID (List<clsItem> items)
        {
            try
            {
                // Integer that stores the largest value found in the Items table. 
                int max = 0;

                // Foreach that handles finding the largest item id value within the List<clsItem> items parameter 
                foreach (clsItem item in items)
                {
                    if (max < int.Parse (item.ItemID.ToString ()))
                    {
                        max = int.Parse (item.ItemID.ToString ());  // If the present item is larger than the max value stored in the previous index, it updates the maximum value
                    }
                }

                return ++max;   // returns the max item ID value incremented by one
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes the item that the user selected from the datagrid in the Items Window UI. 
        /// </summary>
        /// <param name="itemID"> Item id of the selected item from the datagrid from the Items Window UI </param>
        public static void DeleteItem (int itemID)
        {
            try
            {
                // Calls the clsItemsSQL static member DeleteItem (), passing in the id of the item to be deleted
                clsItemsSQL.DeleteItem (itemID);
            }
            catch (Exception ex) // Exception handling
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
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
        public static void EditItem (int itemID, string itemName, decimal itemPrice)
        {
            // basic input checking to avoid exceptions being thrown. Our database currently only supports a maximum string length of 10, so this
            // if-else just makes sure that the item name passed in does not cause an exception. 
            if (itemName.Length <= 10) 
                clsItemsSQL.EditItem (itemID, itemName, itemPrice); // Calls the clsItemsSQL member EditItem, passes in the params for the method
            else if (itemName.Length > 10)
            {
                // Similar to the above EditItem call from clsItemsSQL, but uses a substring to pull the first 10 characters from the Name input,
                // so as to avoid an exception being unneccesarily thrown.
                clsItemsSQL.EditItem (itemID, itemName.Substring (0, 10), itemPrice); 
            }
        }
    }
}
