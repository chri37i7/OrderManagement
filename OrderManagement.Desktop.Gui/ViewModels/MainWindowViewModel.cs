using OrderManagement.DataAccess.Base;
using OrderManagement.DataAccess.Entities.Models;
using OrderManagement.DataAccess.Factory;
using OrderManagement.Desktop.Gui.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrderManagement.Utilities;

namespace OrderManagement.Desktop.Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        protected ObservableCollection<Customer> customers;
        protected string customerId;
        protected string customerPw;

        public MainWindowViewModel()
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

        public virtual string CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                SetProperty(ref customerId, value);
            }
        }

        public virtual string CustomerPw
        {
            get
            {
                return customerPw;
            }
            set
            {
                SetProperty(ref customerPw, value);
            }
        }

        protected override async Task LoadAllAsync()
        {
            // Create Factory
            RepositoryFactory<RepositoryBase<Customer>, Customer> factory =
                new RepositoryFactory<RepositoryBase<Customer>, Customer>();

            // Create Repository
            RepositoryBase<Customer> customerRepository = factory.Create();

            // Get all products from the database
            IEnumerable<Customer> customers = await customerRepository.GetAllAsync();

            // Replace Observable Collection
            Customers.ReplaceWith(customers);
        }
    }
}