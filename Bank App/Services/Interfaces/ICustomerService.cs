using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO CreateCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerRequestModel customer);
       CustomerRequestModel DeleteCustomer(string customerId);
       Customer Login(string email, string passWord);
       CustomerRequestModel GetCustomerByAccountnumber(string accountNumber);
       IList<Customer> GetAllCustomer(); 
       Customer GetCustomerByEmail(string email);
       string NumberOfCustomer();
         
    }
}