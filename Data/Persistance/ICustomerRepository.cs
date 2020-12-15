using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Persistance
{
    public interface ICustomerRepository
    {
        public void AddNewCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public List<Customer> GetCustomers();
        public Customer GetCustomerByID(int customerID);
        public void DeleteCustomerByID(int customerID);
    }
}
