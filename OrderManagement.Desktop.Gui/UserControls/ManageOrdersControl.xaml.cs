using OrderManagement.Desktop.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManagement.Desktop.Gui.UserControls
{
    /// <summary>
    /// Interaction logic for ManageOrdersControl.xaml
    /// </summary>
    public partial class ManageOrdersControl : UserControl
    {
        private string customer;
        private OrderViewModel viewModel;

        public ManageOrdersControl()
        {
            InitializeComponent();
        }

        public ManageOrdersControl(string customer)
        {
            InitializeComponent();

            viewModel = DataContext as OrderViewModel;

            this.customer = customer;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await viewModel.InitializeAsync();

            viewModel.Orders = viewModel.Customers
                .FirstOrDefault(c => c.CustomerId == customer).Orders
                .OrderByDescending(x => x.RequiredDate);

            label.Content = customer;
        }
    }
}
