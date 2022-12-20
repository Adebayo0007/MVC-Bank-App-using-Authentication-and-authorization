using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
       Customer DeleteCustomer(string customerId);
       Customer Login(string email, string passWord);
       Customer GetCustomerByAccountnumber(string accountNumber);
       IList<Customer> GetAllCustomer(); 
         
    }
}