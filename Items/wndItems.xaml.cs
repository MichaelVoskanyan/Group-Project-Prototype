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
using System.Windows.Shapes;

namespace CS3280_Group_Project {
	/// <summary>
	/// Interaction logic for wndItems.xaml
	/// </summary>
	public partial class wndItems : Window {

		public MainWindow MainWindow;

		public wndItems () {
			InitializeComponent ();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
		}

		private void btn_close_Click(object sender, RoutedEventArgs e)
        {
			this.Hide();
			MainWindow = new MainWindow();
			MainWindow.ShowDialog();

		}
    }
}
