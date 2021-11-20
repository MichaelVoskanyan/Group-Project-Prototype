using System;
using System.Reflection;
using System.Windows;

namespace CS3280_Group_Project
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {

        public MainWindow MainWindow;

        clsItemsSQL itemSQL = new clsItemsSQL ();


        public wndItems ()
        {
            InitializeComponent ();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
        }

        private void btn_close_Click (object sender, RoutedEventArgs e)
        {
            this.Hide ();
            MainWindow = new MainWindow ();
            MainWindow.ShowDialog ();

        }

        private void add_item_button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                decimal parse;
                if (item_name_input.Text.ToString () != "" && decimal.TryParse (item_price_input.Text, out parse))
                {
                    if (item_name_input.Text.ToString ().Length <= 10)
                        clsItemsLogic.InsertItem (item_name_input.Text.ToString (), parse);
                    else if (item_name_input.Text.ToString ().Length > 10)
                        clsItemsLogic.InsertItem (item_name_input.Text.ToString ().Substring (0, 10), parse);
                    warning_label.Content = "";
                }
                else
                {
                    item_name_input.Text = "";
                    item_price_input.Text = "";
                    warning_label.Content = "Please input a valid name and price";
                }
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }

            display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
        }

        private void delete_item_button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                if (display_data_grid.SelectedItem != null)
                {
                    clsItem item = (clsItem)display_data_grid.SelectedItem;

                    clsItemsLogic.DeleteItem (item.ItemID);
                }
            }
            catch (Exception ex)
            {
                exception_textblock.Text = ex.Message;
            }

            display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
        }

        private void edit_item_button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                clsItem item = (clsItem)display_data_grid.SelectedItem;

                clsItemsLogic.EditItem (item.ItemID, item.Name, item.Price);
            }
            catch (Exception ex)
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }

            display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
        }
    }
}
