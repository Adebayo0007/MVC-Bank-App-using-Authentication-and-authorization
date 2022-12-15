using Bank_App.Models;

namespace Bank_App.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
       void DeleteCustomerUsingAccountNumber(string accountNumber);
       Customer Login(string email, string passWord);
       Customer GetCustomerByAccountnumber(string accountNumber);
       IList<Customer> GetAllCustomer(); 
         
    }
}