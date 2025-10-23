using Services.Services.Implementations;
using Services.Services.Interfaces;
using BusinessObjects;
using HoangTranManhDungWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HoangTranManhDungWPF.ViewModels.Customer
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;

        private BusinessObjects.Customer _currentCustomer;
        public BusinessObjects.Customer CurrentCustomer
        {
            get => _currentCustomer;
            set => SetProperty(ref _currentCustomer, value);
        }

        public ICommand UpdateProfileCommand { get; }

        public ProfileViewModel(BusinessObjects.Customer loggedInCustomer)
        {
            _customerService = new CustomerService();

            CurrentCustomer = loggedInCustomer;

            UpdateProfileCommand = new RelayCommand(UpdateProfile);
        }

        private void UpdateProfile()
        {
            if (string.IsNullOrWhiteSpace(CurrentCustomer.CustomerFullName) ||
                string.IsNullOrWhiteSpace(CurrentCustomer.Telephone))
            {
                MessageBox.Show("Full Name and Telephone are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _customerService.UpdateCustomer(CurrentCustomer);
            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
