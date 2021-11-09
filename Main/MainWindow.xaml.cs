using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        /// <summary>
        /// constructor to load form when an order has been selected from the search window
        /// </summary>
        /// <param name="OrderID"></param>
        public MainWindow( int OrderID)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lblOrderNumber.Content = OrderID.ToString();
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
    }
}
