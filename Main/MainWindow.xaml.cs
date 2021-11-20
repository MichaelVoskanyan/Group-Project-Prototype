﻿using System.Collections.Generic;
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
        public MainWindow ()
        {
            InitializeComponent ();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            loadOrders ();
        }

        /// <summary>
        /// constructor to load form when an order has been selected from the search window
        /// </summary>
        /// <param name="OrderID"></param>
        public MainWindow (int OrderID)
        {
            InitializeComponent ();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lblOrderNumber.Content = OrderID.ToString ();
            loadOrders ();
        }

        public void loadOrders ()
        {
            List<clsOrder> orderlist = clsMainLogic.GetOrders ();
            var bindingList = new BindingList<clsOrder> (orderlist);
            var source = new BindingSource (bindingList, null);
            orderGrid.ItemsSource = source;
        }

        /// <summary>
        /// search orders selected. hide main and open search form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click (object sender, RoutedEventArgs e)
        {
            wndSearch = new wndSearch ();
            this.Hide ();
            wndSearch.ShowDialog ();

        }

        /// <summary>
        /// menu item selected. hide main and open item form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1 (object sender, RoutedEventArgs e)
        {
            wndItems = new wndItems ();
            this.Hide ();
            wndItems.ShowDialog ();
        }

        /// <summary>
        /// menu exit option. kill application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_2 (object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown ();
        }
    }
}
