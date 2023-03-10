
using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
       Customer CreateCustomer(Customer customer);
       Customer UpdateCustomer(Customer customer);
       Customer DeleteCustomer(Customer customer);
       Customer GetCustomerByAccountnumber(string accountNumber);
       IList<Customer> GetAllCustomer(); 
       string NumberOfCustomer();
       Customer GetCustomerByEmail(string email);
    }
}