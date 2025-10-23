using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Repositories.Implementations;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = CustomerRepository.Instance;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            var allCustomers = _customerRepository.GetCustomers();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return allCustomers;
            }

            string lowerKeyword = keyword.ToLower();
            return allCustomers
                .Where(c => c.CustomerFullName.ToLower().Contains(lowerKeyword) ||
                            c.EmailAddress.ToLower().Contains(lowerKeyword) ||
                            c.Telephone.Contains(keyword))
                .ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
