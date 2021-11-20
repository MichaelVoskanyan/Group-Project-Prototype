
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CS3280_Group_Project
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {


		public MainWindow MainWindow;
		/// <summary>
		/// int ID of order selected
		/// </summary>
		private int ID;

		public wndSearch() 
		{
			InitializeComponent ();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

			loadOrdersDataGrid();

			loadInvoiceNumberComboBox();

			loadInvoiceDateComboBox();

			loadTotalChargeComboBox();

		}

		private void loadInvoiceNumberComboBox()
        {
			try
			{
				//needs to load cboInvoiceNumber
				//trying to pass a list of type int for the invoice numbers from the database
				List<int> invoiceNumberList = clsSearchLogic.GetInvoiceNumbers();
				var bindingList = new BindingList<int>(invoiceNumberList);
				var source = new BindingSource(bindingList, null);
				cboInvoiceNumber.ItemsSource = source;
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

		private void loadInvoiceDateComboBox()
        {
			try
			{
				//needs to load cboInvoiceDate
				List<DateTime> invoiceDateList = clsSearchLogic.GetInvoiceDates();
				var bindingList = new BindingList<DateTime>(invoiceDateList);
				var source = new BindingSource(bindingList, null);
				cboInvoiceDate.ItemsSource = source;
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}

		}

		private void loadTotalChargeComboBox()
        {
			try
			{
				//needs to load cboTotalCharge
				List<decimal> totalChargesList = clsSearchLogic.GetTotalCharges();
				var bindingList = new BindingList<decimal>(totalChargesList);
				var source = new BindingSource(bindingList, null);
				cboTotalCharge.ItemsSource = source;
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

		private void loadOrdersDataGrid()
        {
			try
			{
				List<clsOrder> orderlist = clsSearchLogic.GetOrders();
				var bindingList = new BindingList<clsOrder>(orderlist);
				var source = new BindingSource(bindingList, null);
				searchOrderGrid.ItemsSource = source;
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
			try
			{
				MainWindow = new MainWindow();
				this.Hide();
				MainWindow.ShowDialog();
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

        private void btnSelect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				//Once an order is selected in the datagrid the orderID is set in the DataGrid_SelectionChanged() method
				//and a new MainWindow is created with the ID being passed to the MainWindow constructor
				MainWindow = new MainWindow(ID);
				this.Hide();
				MainWindow.ShowDialog();
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}			
		}

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			try
			{
				//orderID is set when selection is made in datagrid
				clsOrder order = (clsOrder)searchOrderGrid.SelectedItem;
				ID = order.OrderID;
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}						
		}

        private void cboInvoiceNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				try
				{
					
				}
				catch (Exception ex)
				{
					HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
								MethodInfo.GetCurrentMethod().Name, ex.Message);
				}
				finally
				{
					//This code always executes
				}
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

        private void cboInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			try
			{
				try
				{
					
				}
				catch (Exception ex)
				{
					HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
								MethodInfo.GetCurrentMethod().Name, ex.Message);
				}
				finally
				{
					//This code always executes
				}
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

        private void cboTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			try
			{
				
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
			try
			{
				
			}
			catch (Exception ex)
			{
				HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
							MethodInfo.GetCurrentMethod().Name, ex.Message);
			}
			finally
			{
				//This code always executes
			}
		}

		private void HandleError(string sClass, string sMethod, string sMessage)
		{
			try
			{
                System.Windows.MessageBox.Show(sClass + "." + sMethod + "->" + sMessage);
			}
			catch (Exception ex)
			{
				System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
								"HandleError Exception: " + ex.Message);
			}
		}
	}

