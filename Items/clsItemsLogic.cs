using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;



namespace CS3280_Group_Project
{
    class clsItemsLogic
    {

        public clsItemsLogic ()
        {

        }

        public static List<clsItem> GetItems ()
        {
            try
            {
                List<clsItem> itemsList = new List<clsItem> ();
                DataSet ds = clsItemsSQL.GetItems ();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    clsItem tempItem = new clsItem (int.Parse (ds.Tables[0].Rows[i][0].ToString ()),
                        ds.Tables[0].Rows[i][1].ToString (), decimal.Parse (ds.Tables[0].Rows[i][2].ToString ()));

                    itemsList.Add (tempItem);
                }

                return itemsList;
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        public static void InsertItem (string itemName, decimal itemPrice)
        {
            try
            {
                clsItemsSQL.InsertItem (IncItemID (GetItems ()), itemName, itemPrice);
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
        }

        public static int IncItemID (List<clsItem> items)
        {
            try
            {
                int max = 0;

                foreach (clsItem item in items)
                {
                    if (max < int.Parse (item.ItemID.ToString ()))
                    {
                        max = int.Parse (item.ItemID.ToString ());
                    }
                }

                return ++max;
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
                clsItemsSQL.DeleteItem (itemID);
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }

        }

        public static void EditItem (int itemID, string itemName, decimal itemPrice)
        {
            if (itemName.Length <= 10) 
                clsItemsSQL.EditItem (itemID, itemName, itemPrice);
            else if (itemName.Length > 10)
            {
                clsItemsSQL.EditItem (itemID, itemName.Substring (0, 10), itemPrice);
            }
        }
    }
}
