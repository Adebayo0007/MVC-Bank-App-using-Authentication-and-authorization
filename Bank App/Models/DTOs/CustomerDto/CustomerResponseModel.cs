using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models.DTOs.CustomerDto
{
    public class CustomerResponseModel
    {
        [DisplayName("First Name")]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        public string LastName {get;set;}
        public byte[]? ProfilePicture {get; set;}
        public string Address {get;set;}
        public int Age {get;set;}
        public GenderType Gender {get;set;}
         [DisplayName("Marital Status")]
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
         [DisplayName("Phone Number")]
        public string PhoneNumber {get;set;}
        [DisplayName("Password")]
        public string PassWord {get;set;}
          [DisplayName("Account Number")]
        public string AccountNumber {get; set;}
        public string Pin           {get; set;}
         [DisplayName("Account Type")]
        public AccountType AccountType   {get; set;}
        [DisplayName("Account Balance")]
        public double AccountBalance {get; set;}
         public bool IsActive {get;set;} 
        public DateTime DateCreated {get; set;} 
        
    }
}