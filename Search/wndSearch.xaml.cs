
using System;
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

        /// <summary>
        /// class to hold data for mainwindow
        /// </summary>
        public MainWindow MainWindow;
        /// <summary>
        /// boolean datagridID
        /// </summary>
        int datagridID;
        /// <summary>
        /// boolean ID
        /// </summary>
        bool ID;
        /// <summary>
        /// boolean date
        /// </summary>
        bool date;
        /// <summary>
        /// boolean total
        /// </summary>
        bool total;
        /// <summary>
        /// invoice number of order
        /// </summary>
        int orderID;
        /// <summary>
        /// date of order
        /// </summary>
        DateTime orderdate;
        /// <summary>
        /// decimal orderTotal
        /// </summary>
        decimal ordertotal;
        /// <summary>
        /// constructor for search window
        /// </summary>
        /// 
        public wndSearch()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            datagridID = 0;

            ID = false;
            date = false;
            total = false;

            loadOrdersDataGrid();

            loadInvoiceNumberComboBox();

            loadInvoiceDateComboBox();

            loadTotalChargeComboBox();
        }

        /// <summary>
        /// method to select an invoice number from the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ID = true;

                clsOrder order = (clsOrder)cboInvoiceNumber.SelectedItem;
                orderID = order.OrderID;

                if(ID != false && date == false && total == false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID != false && date != false && total == false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID, orderdate);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID != false && date != false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID, orderdate, ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID != false && date == false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID,ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
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

        /// <summary>
        /// method to select an invoice data from the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                date = true;

                clsOrder order = (clsOrder)cboInvoiceDate.SelectedItem;
                orderdate = order.OrderDate;

                if(ID != false && date != false && total == false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID, orderdate);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID != false && date != false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID, orderdate, ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID == false && date != false && total == false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderdate);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID == false && date != false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderdate, ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
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

        /// <summary>
        /// method to select a total charge from the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                total = true;

                clsOrder order = (clsOrder)cboTotalCharge.SelectedItem;
                ordertotal = order.OrderTotal;

                if(ID != false && date != false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID, orderdate, ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID == false && date != false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderdate, ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID == false && date == false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
                }
                if(ID != false && date == false && total != false)
                {
                    List<clsOrder> orderlist = clsSearchLogic.GetFilteredOrders(orderID, ordertotal);
                    var bindingList = new BindingList<clsOrder>(orderlist);
                    var source = new BindingSource(bindingList, null);
                    searchOrderGrid.ItemsSource = source;
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

        /// <summary>
        /// method used to select an invoice number from the order data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //orderID is set when selection is made in datagrid
                clsOrder order = (clsOrder)searchOrderGrid.SelectedItem;
                datagridID = order.OrderID;
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

        /// <summary>
        /// A clear selection button should reset the form to its initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loadOrdersDataGrid();
                cboInvoiceNumber.SelectedIndex = -1;
                cboInvoiceDate.SelectedIndex = -1;
                cboTotalCharge.SelectedIndex = -1;
                datagridID = 0;
                ID = false;
                date = false;
                total = false;
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

        /// <summary>
        /// method to get list of invoice numbers from logic class and load into invoice number combo box
        /// </summary>
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

        /// <summary>
        /// method to get list of dates from logic class and load them into invoice data combo box
        /// </summary>
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

        /// <summary>
        /// method to get list of total charges from logic class and fill total charge combo box
        /// </summary>
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

        /// <summary>
        /// method to get all order info from logic class and load into order data grid
        /// </summary>
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

        /// <summary>
        /// method to select an order and pass that order to the main window. ID is passed to overloaded constructor to load form with an order already selected to edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //when the invoice is selected, the Invoice ID is saved in a local variable
                //that the main window can access.
                if(datagridID != 0)
                {
                    this.Close();
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

        /// <summary>
        /// the search window should close and the main form get focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
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
       
        /// <summary>
        /// method for error handling
        /// </summary>
        /// <param name="sClass">Error Class</param>
        /// <param name="sMethod">Error Method</param>
        /// <param name="sMessage">Error Message</param>
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
}

