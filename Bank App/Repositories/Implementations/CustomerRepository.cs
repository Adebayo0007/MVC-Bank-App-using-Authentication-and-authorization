using Bank_App.Models;
using Bank_App.Repositories.Interfaces;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Implementations
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

        public void DeleteCustomerUsingAccountNumber(Customer accountNumber)
        {
             _context.Customers.Remove(accountNumber);
             _context.SaveChanges();
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