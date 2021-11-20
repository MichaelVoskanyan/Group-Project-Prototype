/* Michael Voskanyan
 * File edited date: 11/20/2021
 * Filename: wndItems.xaml.cs
 * Description:
 * This file contains all the UI logic for the Items window. It handles the button clicks
 * as well as passing user input into the Items logic class. The window contains a datagrid 
 * which displays the list of items pulled by the SQL and Logic classes. The window also 
 * contains 4 buttons, 'Add Item,' 'Delete Item,' 'Edit Item,' and 'Close.' The buttons perform
 * the actions their names suggest they do. Add Item adds a new item based on the user input 
 * in the two text boxes for the item name and item price. The Database automatically increments
 * the item ID, so that is not handled by any c# method/function. If the textboxes are empty, or 
 * contain invalid inputs, there is a warning label that displays a message to inform the user
 * of that fact. The delete item works as follows, first the user must select an item from the 
 * data grid, then click the delete button. If there is no item selected, the delete button will
 * not work. The last item is the edit button, which as of now does not work. It is supposed to 
 * take an item name and price from the textboxes, as well as a selected item in the datagrid
 * through which it pulls an item number. It then calls the Items logic and through there the 
 * Items SQL methods for EditItem (...). The methods do not actually change the item name as of 
 * now. 
 */
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

        /// <summary>
        /// Contructor for the wndItems window. 
        /// </summary>
        public wndItems ()
        {
            // Initializes the window and components within it
            InitializeComponent ();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Initializes the datagrid, fills it with a list of (clsItem)'s for the user to see
            display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
        }

        /// <summary>
        /// This button is used to hide this window and move back to the main window.
        /// It hides the items window and creates and opens a new instance of the 
        /// main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click (object sender, RoutedEventArgs e)
        {
            // Hides this window
            this.Hide ();
            // Creates a new instance of MainWindow
            MainWindow = new MainWindow ();
            // Shows the new MainWindow
            MainWindow.ShowDialog ();

        }

        /// <summary>
        /// This method handles the clicking of the "Add Item" button. When the button is clicked
        /// the method checks to see if the two text boxes, Item Name and Item Price have been filled
        /// and if their input is valid. If it is not, the label warning_label is updated with a 
        /// message to tell the user to check/correct their input. If there is no issue with the user
        /// input, it calls the InsertItem method in the items logic class, then updates the list displayed
        /// in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_item_button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                // Decimal var which contains the parsed decimal value from the Item Price textbox
                decimal parse;
                // Checks to see that both inputs aren't empty
                if (item_name_input.Text.ToString () != "" && decimal.TryParse (item_price_input.Text, out parse))
                {
                    // Due to a bug in the database we are using, the character limit for an item name is set to 10. This checks to 
                    // see if the item name length is less than 10.
                    if (item_name_input.Text.ToString ().Length <= 10)
                        clsItemsLogic.InsertItem (item_name_input.Text.ToString (), parse); // if the item name < 10, it sends the whole item name to the InsertItem method
                    else if (item_name_input.Text.ToString ().Length > 10)
                        clsItemsLogic.InsertItem (item_name_input.Text.ToString ().Substring (0, 10), parse); // If longer than 10, it sends the substring up to the 10th char in the string
                    warning_label.Content = ""; // resets the warning label in case it was displaying a message from a previous error. 

                    // Updates the datagrid to display an updates list of items.
                    display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
                }
                else // If either element is blank
                {
                    // Resets the textboxes for the user to re-enter the new item name and price
                    item_name_input.Text = "";
                    item_price_input.Text = "";
                    // Updates the warning label, informing the user their input was not valid.
                    warning_label.Content = "Please input a valid name and price";
                }
            }
            catch (Exception ex) // Exception handling for the above code within the try block
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }
     
        }

        /// <summary>
        /// This method handles the clicking of the delete item button. There is a check to see
        /// if an item has been selected, and if there isn't it displays a warning in the warning
        /// label in the window. Once the item is deleted, it updates the datagrid to display the 
        /// change to the Database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_item_button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                // Checks if an item has been selected
                if (display_data_grid.SelectedItem != null)
                {
                    // the selected item is passed into a clsItem object, so that the item ID can be passed into the DeleteItem method
                    clsItem item = (clsItem)display_data_grid.SelectedItem;

                    // runs the DeleteItem method in the Items Logic class, passes the itemID as a parameter
                    clsItemsLogic.DeleteItem (item.ItemID);

                    // updates the datagrid to reflect the changes in the database
                    display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
                }
            }
            /*  This catch block doesn't throw an exception that freezes the entire program on debugging, but instead displays
                the exception message in a textblock on the window. This was for debugging purposes, but I figured it looked better
                than if the entire program stopped in case of an exception. */
            catch (Exception ex) 
            {
                exception_textblock.Text = ex.Message;
            }

        }

        /// <summary>
        /// This method handles the edit item button being clicked. When the button is clicked, the method
        /// pulls the selection from the datagrid and casts it as a clsItem. This is to pull the item id from
        /// the selection. The method then pulls the item name and item price from the textboxes and updates the
        /// item name and item price for the item id selected. The code does not work as of right now, and for that
        /// reason there is no input validation at the moment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edit_item_button_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                // Creates a new clsItem which contains the datagrids selected item.
                clsItem item = (clsItem)display_data_grid.SelectedItem;

                // Item ID is pulled from the new clsItem above, and the new item name and price are pulled from the textboxes, (EDITING DOESN'T HAPPEN IN THE DATAGRID)
                clsItemsLogic.EditItem (item.ItemID, item_name_input.ToString (), decimal.Parse (item_price_input.Text.ToString ()));

                // Updates the datagrid to reflect the "changes" to the item
                display_data_grid.ItemsSource = clsItemsLogic.GetItems ();
                /* Console.WriteLine (item.ItemID);
                Console.WriteLine (item_name_input.Text.ToString ());
                Console.WriteLine (decimal.Parse (item_price_input.Text.ToString ())); */
            }
            catch (Exception ex) // Normal exception handling for this method. 
            {
                throw new Exception (MethodInfo.GetCurrentMethod ().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod ().Name + " -> " + ex.Message);
            }

            
        }
    }
}
