using Services.Services.Implementations;
using Services.Services.Interfaces;
using BusinessObjects;
using HoangTranManhDungWPF.ViewModels.Base;
using HoangTranManhDungWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace HoangTranManhDungWPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        private readonly ICustomerService _customerService;

        public LoginViewModel()
        {
            _customerService = new CustomerService();
            LoginCommand = new RelayCommand<PasswordBox>(Login);
        }

        private void Login(PasswordBox passwordBox)
        {
            string password = passwordBox.Password;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
            {
                ErrorMessage = "Email and password are required.";
                return;
            }

            string adminEmail = AppConfig.GetAdminEmail();
            string adminPassword = AppConfig.GetAdminPassword();

            if (Email.Equals(adminEmail, System.StringComparison.OrdinalIgnoreCase)
                && password == adminPassword)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                CloseWindow();
                return;
            }

            BusinessObjects.Customer customer = _customerService.GetCustomerByEmail(Email);
            if (customer != null && customer.Password == password)
            {
                if (customer.CustomerStatus == 2)
                {
                    ErrorMessage = "Your account has been deactivated.";
                    return;
                }

                CustomerWindow customerWindow = new CustomerWindow(customer);
                customerWindow.Show();
                CloseWindow();
                return;
            }

            ErrorMessage = "Invalid email or password!";
        }

        private void CloseWindow()
        {
            var loginWindow = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
            loginWindow?.Close();
        }
    }
}
