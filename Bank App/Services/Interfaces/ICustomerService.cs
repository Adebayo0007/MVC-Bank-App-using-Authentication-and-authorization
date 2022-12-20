using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerRequestModel customer);
       Customer DeleteCustomer(string customerId);
       Customer Login(string email, string passWord);
       CustomerRequestModel GetCustomerByAccountnumber(string accountNumber);
       IList<Customer> GetAllCustomer(); 
         
    }
}