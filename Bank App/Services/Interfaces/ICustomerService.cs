using Bank_App.Models;

namespace Bank_App.Services.Interfaces
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