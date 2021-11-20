
﻿using System;
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
		public static DataSet GetOrders()
		{
			try
			{
				clsDataAccess da = new clsDataAccess();
				//Create a DataSet to hold the data
				DataSet ds = new DataSet();

				int iRet = 0;

				ds = da.ExecuteSQLStatement(
					   "SELECT Orders.Order_ID, Orders.Order_Date, Sum(Items.Price) AS SumOfPrice, Count(Items.Item) AS CountOfItem" +
					  " FROM Items INNER JOIN (Orders INNER JOIN Order_Items ON Orders.Order_ID = Order_Items.Order_ID) ON Items.Item_ID = Order_Items.Item_ID" +
					  "  GROUP BY Orders.Order_ID, Orders.Order_Date", ref iRet);

				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
							MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
			}
        }

		public static DataSet GetInvoiceNumbers()
        {
			try
			{
				clsDataAccess da = new clsDataAccess();
				//Create a DataSet to hold the data
				DataSet ds = new DataSet();

				int iRet = 0;

				ds = da.ExecuteSQLStatement("/* need SQL here for invoice numbers*/", ref iRet);

				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
							MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
			}
		}

		public static DataSet GetInvoiceDates()
        {
			try
			{
				clsDataAccess da = new clsDataAccess();
				//Create a DataSet to hold the data
				DataSet ds = new DataSet();

				int iRet = 0;

				ds = da.ExecuteSQLStatement("/* need SQL here for invoice dates*/", ref iRet);

				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
							MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
			}
		}

		public static DataSet GetTotalCharges()
        {
			try
			{
				clsDataAccess da = new clsDataAccess();
				//Create a DataSet to hold the data
				DataSet ds = new DataSet();

				int iRet = 0;

				ds = da.ExecuteSQLStatement("/* need SQL here for invoice dates*/", ref iRet);

				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
							MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
			}
		}
	}


