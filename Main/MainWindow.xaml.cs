using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace CS3280_Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// class to hold item window data
        /// </summary>
        public wndItems wndItems;
        /// <summary>
        /// class to hold search window data
        /// </summary>
        public wndSearch wndSearch;

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                loadOrders();
                loadItems();
                DisableForm();
                orderGrid.IsReadOnly = true;
                dgItemGrid.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// constructor to load form when an order has been selected from the search window
        /// </summary>
        /// <param name="OrderID"></param>
        public MainWindow(clsOrder Order)
        {
            try
            {
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                InitializeComponent();
                loadOrders();
                clsMainLogic.currentOrder = Order;
                lblOrderNumber.Content = Order.OrderID.ToString();
                dpOrderDate.SelectedDate = Order.OrderDate;
                loadItems();
                loadOrderItems(clsMainLogic.currentOrder);
                cb_chooseItem.SelectedIndex = -1;
                DisableForm();
                orderGrid.IsReadOnly = true;
                dgItemGrid.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method to load orders from db into the order data grid
        /// </summary>
        public void loadOrders()
        {
            try
            {
                List<clsOrder> orderlist = clsMainLogic.GetOrders();
                var bindingList = new BindingList<clsOrder>(orderlist);
                var source = new BindingSource(bindingList, null);
                orderGrid.ItemsSource = source;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method to load items into the item combo box
        /// </summary>
        public void loadItems()
        {
            try
            {
                List<clsItem> itemList = clsMainLogic.GetItems();
                var bindingList = new BindingList<clsItem>(itemList);
                var source = new BindingSource(bindingList, null);
                cb_chooseItem.ItemsSource = source;
                cb_chooseItem.DisplayMemberPath = "Name";
                cb_chooseItem.SelectedValuePath = "ItemID";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method to load item orders into the items data grid
        /// </summary>
        /// <param name="selectedOrder">selected order</param>
        public void loadOrderItems(clsOrder selectedOrder)
        {
            try
            {
                List<clsItem> itemList = clsMainLogic.GetOrderItems(selectedOrder.OrderID);
                clsMainLogic.OrderItems = itemList;
                var bindingList = new BindingList<clsItem>(clsMainLogic.OrderItems);
                var source = new BindingSource(bindingList, null);
                dgItemGrid.ItemsSource = source;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// disable the functions of the form except edit add and delete order
        /// </summary>
        public void DisableForm()
        {
            try
            {
                dpOrderDate.IsEnabled = false;
                cb_chooseItem.IsEnabled = false;
                btnAddItem.IsEnabled = false;
                btnRemoveItem.IsEnabled = false;
                btn_submit.IsEnabled = false;
                dgItemGrid.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// enable the functions of the form except edit add and delete order
        /// </summary>
        public void EnableForm()
        {
            try
            {
                dpOrderDate.IsEnabled = true;
                cb_chooseItem.IsEnabled = true;
                btnAddItem.IsEnabled = true;
                btnRemoveItem.IsEnabled = true;
                btn_submit.IsEnabled = true;
                dgItemGrid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// search orders selected. hide main and open search form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clsMainLogic.isEditing || clsMainLogic.isloadingNew)
                {
                    return;
                }
                wndSearch = new wndSearch();
                this.Hide();
                wndSearch.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// menu item selected. hide main and open item form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clsMainLogic.isEditing || clsMainLogic.isloadingNew)
                {
                    return;
                }
                wndItems = new wndItems();
                //this.Hide();
                wndItems.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// menu exit option. kill application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// event handler for edit button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //check if item is selected or currently editing or adding a new item
                if (clsMainLogic.currentOrder is null || clsMainLogic.isEditing || clsMainLogic.isloadingNew)
                {
                    return;
                }
                clsMainLogic.isEditing = true;
                EnableForm();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// choose item handler. updates the read only text field and selects the item in logic class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_chooseItem_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                clsMainLogic.SelectedItem = (clsItem)cb_chooseItem.SelectedItem;
                if (cb_chooseItem.SelectedIndex != -1)
                {
                    txtPrice.Text = clsMainLogic.SelectedItem.Price.ToString();
                }
                else
                {
                    txtPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// adds the current selected item in the drop down to the orderlist in logic class. updates orderlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((clsItem)cb_chooseItem.SelectedItem is null || lblOrderNumber.Content.ToString() == "")
                {
                    return;
                }
                if (clsMainLogic.OrderItems is null)
                {
                    List<clsItem> Items = new List<clsItem>();
                    clsMainLogic.OrderItems = Items;
                }
                clsMainLogic.OrderItems.Add((clsItem)cb_chooseItem.SelectedItem);

                var bindingList = new BindingList<clsItem>(clsMainLogic.OrderItems);
                var source = new BindingSource(bindingList, null);
                dgItemGrid.ItemsSource = source;
                cb_chooseItem.SelectedIndex = -1;
                clsMainLogic.SelectedItem = null;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// event handler to remove the selected item from the ordered item datagrid
        /// updates ordered items datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((clsItem)dgItemGrid.SelectedItem is null)
                {
                    return;
                }
                clsMainLogic.OrderItems.Remove((clsItem)dgItemGrid.SelectedItem);
                var bindingList = new BindingList<clsItem>(clsMainLogic.OrderItems);
                var source = new BindingSource(bindingList, null);
                dgItemGrid.ItemsSource = source;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// event handler for submit button. If app is editing, the order is updated. If the app is adding a new order a new order is inserted. 
        /// If app is not editing or adding item, nothing happens. Disables form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///handle submit method for an item that already exists and is being edited
                if (clsMainLogic.isEditing)
                {
                    clsMainLogic.UpdateOrderItems(clsMainLogic.currentOrder.OrderID);
                    clsMainLogic.isEditing = false;
                    loadOrders();

                }
                ///handle submit method for loading a new order
                else if (clsMainLogic.isloadingNew)
                {
                    if (dpOrderDate.SelectedDate is null || dgItemGrid.Items.Count == 0)
                    {
                        return;
                    }
                    clsMainLogic.AddOrder((DateTime)dpOrderDate.SelectedDate);
                    clsMainLogic.isloadingNew = false;
                    loadOrders();
                    orderGrid.SelectedIndex = orderGrid.Items.Count - 1;
                }
                cb_chooseItem.SelectedIndex = -1;
                DisableForm();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// event handler for delete order. if app is editing or loading new, does nothing. Otherwise, deletes order from order list and updates order list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((clsOrder)orderGrid.SelectedItem is null || clsMainLogic.isEditing || clsMainLogic.isloadingNew)
                {
                    return;
                }
                clsMainLogic.currentOrder = (clsOrder)orderGrid.SelectedItem;
                clsMainLogic.DeleteOrder((clsOrder)orderGrid.SelectedItem);
                if (clsMainLogic.OrderItems is null)
                {

                }
                else
                {
                    clsMainLogic.OrderItems.Clear();
                    dgItemGrid.ItemsSource = clsMainLogic.OrderItems;
                }
                dpOrderDate.SelectedDate = null;
                dpOrderDate.DisplayDate = DateTime.Today;
                lblOrderNumber.Content = "";
                loadOrders();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// event handler for new order. If app is not already loading new item or editing, a new order is started and the form is enabled. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clsMainLogic.isEditing || clsMainLogic.isloadingNew)
                {
                    return;
                }
                lblOrderNumber.Content = "TBD";
                clsMainLogic.isloadingNew = true;
                if (clsMainLogic.OrderItems is null)
                {

                }
                else
                {
                    clsMainLogic.OrderItems.Clear();
                    dgItemGrid.ItemsSource = clsMainLogic.OrderItems;
                }
                dpOrderDate.SelectedDate = null;
                dpOrderDate.DisplayDate = DateTime.Today;
                clsMainLogic.currentOrder = null;
                EnableForm();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method to select a new order from the order grid. Order details and items are loaded and form is enabled. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                if ((clsOrder)orderGrid.SelectedItem is null || clsMainLogic.isEditing || clsMainLogic.isloadingNew)
                {
                    return;
                }
                clsMainLogic.currentOrder = (clsOrder)orderGrid.SelectedItem;
                lblOrderNumber.Content = clsMainLogic.currentOrder.OrderID.ToString();
                dpOrderDate.SelectedDate = clsMainLogic.currentOrder.OrderDate;
                loadOrderItems(clsMainLogic.currentOrder);
                cb_chooseItem.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method to handle all passed in errors
        /// </summary>
        /// <param name="sClass">errored class</param>
        /// <param name="sMethod">errored method</param>
        /// <param name="sMessage">error message</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                System.Windows.MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

    }
}
