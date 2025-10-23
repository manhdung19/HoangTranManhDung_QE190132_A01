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
using BusinessObjects;

namespace HoangTranManhDungWPF.Views.Admin
{
    /// <summary>
    /// Interaction logic for CustomerDialog.xaml
    /// </summary>
    public partial class CustomerDialog : Window
    {
        public BusinessObjects.Customer Customer { get; private set; }
        public Visibility IDVisibility { get; private set; }

        public CustomerDialog(BusinessObjects.Customer customer)
        {
            InitializeComponent();

            if (customer == null)
            {
                Customer = new BusinessObjects.Customer();
                this.Title = "Add New Customer";
                IDVisibility = Visibility.Collapsed;
            }
            else
            {
                Customer = customer;
                this.Title = "Update Customer";
                IDVisibility = Visibility.Visible;
            }

            this.DataContext = Customer;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Customer.CustomerFullName) ||
                string.IsNullOrWhiteSpace(Customer.EmailAddress) ||
                string.IsNullOrWhiteSpace(Customer.Password))
            {
                MessageBox.Show("Full Name, Email, and Password are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Customer.EmailAddress.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
