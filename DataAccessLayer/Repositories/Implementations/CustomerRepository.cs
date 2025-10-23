using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        //Singleton Pattern
        private static CustomerRepository instance = null;
        private static readonly object instanceLock = new object();
        private CustomerRepository() { }
        public static CustomerRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerRepository();
                    }
                    return instance;
                }
            }
        }
        public List<Customer> GetCustomers()
        {
            return MockDatabase.Customers.Where(c => c.CustomerStatus == 1).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return MockDatabase.Customers.FirstOrDefault(c => c.CustomerID == id && c.CustomerStatus == 1);
        }
        public Customer GetCustomerByEmail(string email)
        {
            return MockDatabase.Customers.FirstOrDefault(c => c.EmailAddress.Equals(email));
        }
        public void AddCustomer(Customer customer)
        {
            int newId = MockDatabase.Customers.Max(c => c.CustomerID) + 1;
            customer.CustomerID = newId;
            customer.CustomerStatus = 1;
            MockDatabase.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = MockDatabase.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerFullName = customer.CustomerFullName;
                existingCustomer.Telephone = customer.Telephone;
                existingCustomer.EmailAddress = customer.EmailAddress;
                existingCustomer.CustomerBirthday = customer.CustomerBirthday;
                existingCustomer.Password = customer.Password;
                existingCustomer.CustomerStatus = customer.CustomerStatus;
            }
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = GetCustomerById(id);
            if (customer != null)
            {
                customer.CustomerStatus = 2; // Soft delete
            }
        }
    }
}
