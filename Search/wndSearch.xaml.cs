using System.Windows;

namespace CS3280_Group_Project
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        public MainWindow MainWindow;

        public wndSearch ()
        {
            InitializeComponent ();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnCancel_Click (object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow ();
            this.Hide ();
            MainWindow.ShowDialog ();

        }

        private void btnSelect_Click (object sender, RoutedEventArgs e)
        {
            ///hardcoded 2 to simulate orderID 2 was selected and loaded into main window form
            MainWindow = new MainWindow (2);
            this.Hide ();
            MainWindow.ShowDialog ();
        }
    }
}
