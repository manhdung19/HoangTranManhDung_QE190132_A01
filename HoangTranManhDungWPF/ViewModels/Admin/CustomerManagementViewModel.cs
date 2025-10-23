using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using HoangTranManhDungWPF.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using HoangTranManhDungWPF.Views.Admin;

namespace HoangTranManhDungWPF.ViewModels.Admin
{
    public class CustomerManagementViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;

        private ObservableCollection<BusinessObjects.Customer> _customers;
        public ObservableCollection<BusinessObjects.Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        private BusinessObjects.Customer _selectedCustomer;
        public BusinessObjects.Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                SetProperty(ref _selectedCustomer, value);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand LoadCustomersCommand { get; }
        public ICommand AddCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand SearchCommand { get; }

        public CustomerManagementViewModel()
        {
            _customerService = new CustomerService();
            LoadCustomersCommand = new RelayCommand(LoadCustomers);
            AddCustomerCommand = new RelayCommand(AddCustomer);
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer, CanModify);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, CanModify);
            SearchCommand = new RelayCommand(SearchCustomers);

            LoadCustomers();
        }

        private void LoadCustomers()
        {
            SearchText = string.Empty;
            Customers = new ObservableCollection<BusinessObjects.Customer>(_customerService.GetCustomers());
        }

        private void SearchCustomers()
        {
            Customers = new ObservableCollection<BusinessObjects.Customer>(_customerService.SearchCustomers(SearchText));
        }

        private bool CanModify()
        {
            return SelectedCustomer != null;
        }

        private void DeleteCustomer()
        {
            var result = MessageBox.Show($"Are you sure you want to delete {SelectedCustomer.CustomerFullName}?",
                                         "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(SelectedCustomer.CustomerID);
                LoadCustomers();
            }
        }

        private void AddCustomer()
        {
            CustomerDialog dialog = new CustomerDialog(null);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _customerService.AddCustomer(dialog.Customer);
                LoadCustomers();
            }
        }

        private void UpdateCustomer()
        {
            var customerToUpdate = new BusinessObjects.Customer
            {
                CustomerID = SelectedCustomer.CustomerID,
                CustomerFullName = SelectedCustomer.CustomerFullName,
                Telephone = SelectedCustomer.Telephone,
                EmailAddress = SelectedCustomer.EmailAddress,
                CustomerBirthday = SelectedCustomer.CustomerBirthday,
                Password = SelectedCustomer.Password,
                CustomerStatus = SelectedCustomer.CustomerStatus
            };

            CustomerDialog dialog = new CustomerDialog(customerToUpdate);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _customerService.UpdateCustomer(dialog.Customer);
                LoadCustomers();
            }
        }
    }
}
