using MVC_MobileBankApp.Models.DTOs.CustomerDto;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ICustomerService
    {
        CreateCustomerRequestModel CreateCustomer(CreateCustomerRequestModel customer);
        void UpdateCustomer(UpdateCustomerRequestModel customer);
        CustomerResponseModel DeleteCustomer(string customerId);
        CustomerResponseModel GetCustomerByAccountnumber(string accountNumber);
        IList<CustomerResponseModel> GetAllCustomer(); 
        CustomerResponseModel GetCustomerByEmail(string email);
        string NumberOfCustomer();
         
    }
}