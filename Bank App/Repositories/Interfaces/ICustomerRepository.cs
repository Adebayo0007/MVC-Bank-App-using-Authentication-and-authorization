using Bank_App.Models;
using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
       Customer DeleteCustomer(Customer customer);
       Customer Login(string email, string passWord);
       Customer GetCustomerByAccountnumber(string accountNumber);
       IList<Customer> GetAllCustomer(); 
    }
}