using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories.Interfaces;

namespace MVC_MobileBankApp.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository 
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(Customer customer)
        {
              _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }

        public IList<Customer> GetAllCustomer()
        {
             return _context.Customers.ToList();
        }

        public Customer GetCustomerByAccountnumber(string accountNumber)
        {
            var customer =_context.Customers.SingleOrDefault(a => a.AccountNumber == accountNumber);
            return customer;
        }

        public Customer Login(string email, string passWord)
        {
            return _context.Customers.SingleOrDefault(a => a.Email  == email && a.PassWord == passWord);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}