using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project {
	class clsSearchLogic 
	{
		public static List<clsOrder> GetOrders()
        {
			try
			{
				DataSet dsOrders = clsSearchSQL.GetOrders();

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

		public static List<int> GetInvoiceNumbers()
        {
			try
			{
				DataSet ds = clsSearchSQL.GetInvoiceNumbers();

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

		public static List<DateTime> GetInvoiceDates()
        {
			DataSet ds = clsSearchSQL.GetInvoiceDates();

			List<DateTime> invoiceDateList = new List<DateTime>();

			for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
				//check  this code here to see if it's correct
				DateTime date = DateTime.Parse(ds.Tables[0].Rows[i][1].ToString());

				invoiceDateList.Add(date);
			}

			return invoiceDateList;
        }

		public static List<decimal> GetTotalCharges()
        {
			try
			{
				DataSet ds = clsSearchSQL.GetTotalCharges();

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
