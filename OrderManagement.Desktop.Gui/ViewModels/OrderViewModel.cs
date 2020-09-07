using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Base;
using OrderManagement.DataAccess.Entities.Models;
using OrderManagement.DataAccess.Factory;
using OrderManagement.Desktop.Gui.ViewModels.Base;
using OrderManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Desktop.Gui.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        protected ObservableCollection<Customer> customers;
        protected Order selectedOrder;
        protected IEnumerable<Order> orders;

        public OrderViewModel()
        {
            customers = new ObservableCollection<Customer>();
        }

        public virtual ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                SetProperty(ref customers, value);
            }
        }

        public virtual Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                SetProperty(ref selectedOrder, value);
            }
        }

        public virtual IEnumerable<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                SetProperty(ref orders, value);
            }
        }

        protected override async Task LoadAllAsync()
        {
            // Create Factory
            RepositoryFactory<CustomerRepository, Customer> factory =
                new RepositoryFactory<CustomerRepository, Customer>();

            // Create Repository
            CustomerRepository customerRepository = factory.Create();

            // Get all Customers from the database
            IEnumerable<Customer> customers = await customerRepository.GetAllAsync();

            // Replace Observable Collection
            Customers.ReplaceWith(customers);
        }
    }
}