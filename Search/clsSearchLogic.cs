
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project
{
    class clsSearchLogic
    {
        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchID">Order ID</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(int searchID)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchID), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        
        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchID">Order ID</param>
		/// <param name="searchDate">Order Date</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(int searchID, DateTime searchDate)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchID, searchDate), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchID">Order ID</param>
		/// <param name="searchDate">Order Date</param>
		/// <param name="searchTotal">Order Total</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(int searchID, DateTime searchDate, decimal searchTotal)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchID, searchDate, searchTotal), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchDate">Order Date</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(DateTime searchDate)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchDate), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchDate">Order Date</param>
		/// <param name="searchTotal">Order Total</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(DateTime searchDate, decimal searchTotal)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchDate, searchTotal), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        
        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchTotal">Order Total</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(decimal searchTotal)
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchTotal), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
		/// method to get list of filtered orders
		/// </summary>
		/// <param name="searchID">Order ID</param>
		/// <param name="searchTotal">Order Total</param>
		/// <returns></returns>
        public static List<clsOrder> GetFilteredOrders(int searchID, decimal searchTotal)
        {
            // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetFilteredOrders(searchID, searchTotal), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
        }

        /// <summary>
        /// method to execute get orders qry and create a list of orders. returns list of orders
        /// </summary>
        /// <returns>list of orders</returns>
        public static List<clsOrder> GetOrders()

        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet dsOrders = db.ExecuteSQLStatement(clsSearchSQL.GetOrders(), ref iRets);

                List<clsOrder> orderList = new List<clsOrder>();

                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    clsOrder newOrder = new clsOrder(int.Parse(dsOrders.Tables[0].Rows[i][0].ToString()),
                            DateTime.Parse(dsOrders.Tables[0].Rows[i][1].ToString()),
                            decimal.Parse(dsOrders.Tables[0].Rows[i].ItemArray[2].ToString()));

                    orderList.Add(newOrder);
                }

                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get all invoice numbers from databse and create a list of order numbers
        /// </summary>
        /// <returns>list of order IDs</returns>
        public static List<int> GetInvoiceNumbers()

        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.GetInvoiceNumbers(), ref iRets);

                List<int> invoiceNumberList = new List<int>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //check  this code here to see if it's correct
                    int ID = int.Parse(ds.Tables[0].Rows[i][0].ToString());

                    invoiceNumberList.Add(ID);
                }

                return invoiceNumberList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        /// <summary>
        /// method to get all order dates from DB and return list of all order dates
        /// </summary>
        /// <returns>list of order dates</returns>
        public static List<DateTime> GetInvoiceDates()
        {
            // clsDataAccess object created to run ExecuteSQLStatement method
            clsDataAccess db = new clsDataAccess();
            // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
            int iRets = 0;

            // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
            DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.GetInvoiceDates(), ref iRets);


            List<DateTime> invoiceDateList = new List<DateTime>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //check  this code here to see if it's correct
                DateTime date = DateTime.Parse(ds.Tables[0].Rows[i][1].ToString());

                invoiceDateList.Add(date);
            }

            return invoiceDateList;
        }
        /// <summary>
        /// method to get total charges from DB and create a list of charges
        /// </summary>
        /// <returns>returns a list of total charges</returns>
        public static List<decimal> GetTotalCharges()
        {
            try
            {
                // clsDataAccess object created to run ExecuteSQLStatement method
                clsDataAccess db = new clsDataAccess();
                // integer to be passed as reference into ExecuteSQLStatement, returns the number of results fetched by the SQL Query
                int iRets = 0;

                // DataSet to temporarily hold the data from the clsDataAccess, passes data into the List<clsItem> inside the clsItemsLogic class
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.GetTotalCharges(), ref iRets);

                List<decimal> totalChargesList = new List<decimal>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //check  this code here to see if it's correct
                    decimal charge = decimal.Parse(ds.Tables[0].Rows[i].ItemArray[2].ToString());

                    totalChargesList.Add(charge);
                }

                return totalChargesList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}

