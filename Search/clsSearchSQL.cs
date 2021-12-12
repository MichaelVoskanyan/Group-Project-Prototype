
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project
{
    class clsSearchSQL
    {
        /// <summary>
        /// method to get all order info sql qry
        /// </summary>
        /// <returns></returns>
        public static string GetOrders()
        {
            try
            {
                string sql =
                       "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get all invoice numbers query
        /// </summary>
        /// <returns></returns>
        public static string GetInvoiceNumbers()
        {
            try
            {
                string sql = "Select Order_ID From Orders";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get all invoice dates query
        /// </summary>
        /// <returns></returns>
        public static string GetInvoiceDates()
        {
            try
            {
                string sql = "SELECT Orders.Order_Date" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get all total charges query
        /// </summary>
        /// <returns></returns>
        public static string GetTotalCharges()
        {
            try
            {
                string sql = "SELECT Sum(Items.Price) AS SumOfPrice" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get filtered order list qry with ID
        /// </summary>
        /// <param name="searchID">Order ID</param>
        /// <returns></returns>
        public static string GetFilteredOrders(int searchID)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING Orders.Order_ID=" + searchID.ToString() + ";";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        /// <summary>
        /// method to get filtered ordrer list based on ID and Date
        /// </summary>
        /// <param name="searchID">Order ID</param>
        /// <param name="searchDate">Order Date</param>
        /// <returns></returns>
        public static string GetFilteredOrders(int searchID, DateTime searchDate)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING Orders.Order_ID=" + searchID.ToString() + " AND Orders.Order_Date=#" + searchDate.ToString() + "#;";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get list of filtered orders query with ID, Date and Total
        /// </summary>
        /// <param name="searchID">Order ID</param>
        /// <param name="searchDate">Order Date</param>
        /// <param name="searchTotal">Order Total</param>
        /// <returns></returns>
        public static string GetFilteredOrders(int searchID, DateTime searchDate, decimal searchTotal)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING Orders.Order_ID=" + searchID.ToString() + " AND Orders.Order_Date=#" + searchDate.ToString() + "# AND Sum(Items.Price)=" + searchTotal.ToString() + ";";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get filtered order list query based on order date
        /// </summary>
        /// <param name="searchDate">order date</param>
        /// <returns></returns>
        public static string GetFilteredOrders(DateTime searchDate)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING  Orders.Order_Date=#" + searchDate.ToString() + "#;";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get filtered order list query based on Order Date and Total
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="searchTotal"></param>
        /// <returns></returns>
        public static string GetFilteredOrders(DateTime searchDate, decimal searchTotal)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING  Orders.Order_Date=#" + searchDate.ToString() + "# AND Sum(Items.Price)=" + searchTotal.ToString() + ";";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get filtered order list query based on order total
        /// </summary>
        /// <param name="searchTotal">Order total</param>
        /// <returns></returns>
        public static string GetFilteredOrders(decimal searchTotal)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING Sum(Items.Price)=" + searchTotal.ToString() + ";";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// method to get list of filtered orders query with ID, Date and Total
        /// </summary>
        /// <param name="searchID">Order ID</param>
        /// <param name="searchTotal">Order Total</param>
        /// <returns></returns>
        public static string GetFilteredOrders(int searchID, decimal searchTotal)
        {
            try
            {
                string sql = "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
                      " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
                      " GROUP BY Orders.Order_ID, Orders.Order_Date" +
                      " HAVING Orders.Order_ID=" + searchID.ToString() + " AND Sum(Items.Price)=" + searchTotal.ToString() + ";";
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                            MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}


