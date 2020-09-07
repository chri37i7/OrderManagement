using OrderManagement.Desktop.Gui.UserControls;
using OrderManagement.Desktop.Gui.ViewModels;
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

namespace OrderManagement.Desktop.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        private bool isLoaded;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = DataContext as MainWindowViewModel;
        }

        public UserControl MainContentControl
        {
            get
            {
                return mainContentControl;
            }
            set
            {
                mainContentControl = value;
            }
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(!isLoaded)
            {
                isLoaded = !isLoaded;

                await viewModel.InitializeAsync();
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            string customer = viewModel.CustomerId;
            string password = viewModel.CustomerPw;

            if(CustomerExists(customer) && password == "12345")
            {
                login_Panel.Visibility = Visibility.Collapsed;

                mainContentControl.Content = new ManageOrdersControl(customer);
            }
            else
            {
                MessageBox.Show("Brugeren findes ikke.", "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CustomerExists(string customer)
        {
            return (viewModel.Customers.FirstOrDefault(c => c.CustomerId == customer) != null) ? true : false;
        }
    }
}