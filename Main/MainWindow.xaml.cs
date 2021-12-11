using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            loadOrders();
            loadItems();

        }

        /// <summary>
        /// constructor to load form when an order has been selected from the search window
        /// </summary>
        /// <param name="OrderID"></param>
        public MainWindow(int OrderID)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lblOrderNumber.Content = OrderID.ToString();
            loadOrders();
            loadItems();

        }

        /// <summary>
        /// method to load orders from db into the order data grid
        /// </summary>
        public void loadOrders()
        {
            List<clsOrder> orderlist = clsMainLogic.GetOrders();
            var bindingList = new BindingList<clsOrder>(orderlist);
            var source = new BindingSource(bindingList, null);
            orderGrid.ItemsSource = source;
        }

        /// <summary>
        /// method to load items into the item combo box
        /// </summary>
        public void loadItems()
        {
            List<clsItem> itemList = clsMainLogic.GetItems();
            var bindingList = new BindingList<clsItem>(itemList);
            var source = new BindingSource(bindingList, null);
            cb_chooseItem.ItemsSource = source;
            cb_chooseItem.DisplayMemberPath = "Name";
            cb_chooseItem.SelectedValuePath = "ItemID";
        }

        /// <summary>
        /// method to load item orders into the items data grid
        /// </summary>
        /// <param name="selectedOrder">selected order</param>
        public void loadOrderItems(clsOrder selectedOrder)
        {
            List<clsItem> itemList = clsMainLogic.GetOrderItems(selectedOrder.OrderID);
            clsMainLogic.OrderItems = itemList;
            var bindingList = new BindingList<clsItem>(clsMainLogic.OrderItems);
            var source = new BindingSource(bindingList, null);
            dgItemGrid.ItemsSource = source;
        }

        /// <summary>
        /// search orders selected. hide main and open search form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndSearch = new wndSearch();
            this.Hide();
            wndSearch.ShowDialog();

        }

        /// <summary>
        /// menu item selected. hide main and open item form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            wndItems = new wndItems();
            this.Hide();
            wndItems.ShowDialog();
        }

        /// <summary>
        /// menu exit option. kill application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// event handler for edit button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //check if item is selected or currently editing or adding a new item
            if ((clsOrder)orderGrid.SelectedItem is null || clsMainLogic.isEditing || clsMainLogic.isloadingNew){
                return;
            }
            clsMainLogic.currentOrder = (clsOrder)orderGrid.SelectedItem;
            lblOrderNumber.Content = clsMainLogic.currentOrder.OrderID.ToString();
            dpOrderDate.SelectedDate = clsMainLogic.currentOrder.OrderDate;
            loadOrderItems(clsMainLogic.currentOrder);
            cb_chooseItem.SelectedIndex = -1;
            clsMainLogic.isEditing = true;
        }

        private void cb_chooseItem_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if((clsItem)cb_chooseItem.SelectedItem is null || lblOrderNumber.Content.ToString() == "")
            {
                return;
            }
            clsMainLogic.OrderItems.Add((clsItem)cb_chooseItem.SelectedItem);
            var bindingList = new BindingList<clsItem>(clsMainLogic.OrderItems);
            var source = new BindingSource(bindingList, null);
            dgItemGrid.ItemsSource = source;
            cb_chooseItem.SelectedIndex = -1;
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if((clsItem)dgItemGrid.SelectedItem is null)
            {
                return;
            }
            clsMainLogic.OrderItems.Remove((clsItem)dgItemGrid.SelectedItem);
            var bindingList = new BindingList<clsItem>(clsMainLogic.OrderItems);
            var source = new BindingSource(bindingList, null);
            dgItemGrid.ItemsSource = source;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            ///handle submit method for an item that already exists and is being edited
            if (clsMainLogic.isEditing)
            {
                clsMainLogic.UpdateOrderItems(clsMainLogic.currentOrder.OrderID);
                clsMainLogic.isEditing = false;
                cb_chooseItem.SelectedIndex = -1;
                lblOrderNumber.Content = "";
                dgItemGrid.ItemsSource = null;
                dpOrderDate.SelectedDate = null;
                dpOrderDate.DisplayDate = DateTime.Today;
                loadOrders();
            }
        }
    }
}
