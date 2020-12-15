using Common;
using System.Collections.Generic;
using System.Linq;

namespace Data.Persistance
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiDbContext _apiDbContext;
        private object _locker;

        public CustomerRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
            _locker = new object();
        }

        public void AddNewCustomer(Customer customer)
        {
            lock (_locker)
            {
                _apiDbContext.Customers.Add(customer);
                _apiDbContext.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            lock (_locker)
            {
                _apiDbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _apiDbContext.SaveChanges();
            }
        }

        public List<Customer> GetCustomers()
        {
            return _apiDbContext.Customers.ToList();
        }

        public Customer GetCustomerByID(int customerID)
        {
            return _apiDbContext.Customers.FirstOrDefault(x => x.CustomerID == customerID);
        }

        public void DeleteCustomerByID(int customerID)
        {
            lock (_locker)
            {
                _apiDbContext.Customers.Remove(_apiDbContext.Customers.FirstOrDefault(x => x.CustomerID == customerID));
                _apiDbContext.SaveChanges();
            }
        }
    }
}
