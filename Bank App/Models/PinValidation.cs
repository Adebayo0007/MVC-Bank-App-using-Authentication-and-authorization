using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.CustomerDto;

namespace MVC_MobileBankApp.Models
{
    public class PinValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (CreateCustomerRequestModel)validationContext.ObjectInstance;
            return customer.Pin.Length != 4 ? new ValidationResult("Four digit Pin is required.") : ValidationResult.Success;
            
            //  if(customer.Pin.Length == 4)
            //  return ValidationResult.Success;
            //  else
            //  {
            //  return new ValidationResult("Four digit Pin is required.");
            //  }
            //  var age = DateTime.Today.Year - customer.DateOfbirth.value.Year;;
        }
    }
}