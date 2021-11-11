using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project {
	class clsMainLogic {

		public static clsOrder currentOrder;

        public static List<clsOrder> GetOrders()
        {
            try
            {
                DataSet orders = clsMainSQL.GetOrders();

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

    }
}
