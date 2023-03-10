using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models.DTOs.CustomerDto
{
    public class UpdateCustomerRequestModel
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        // [Required]
        // public byte[]? ProfilePicture {get; set;}
        [Required]
        public string Address {get;set;}
        public int Age {get;set;}
        [Required]
        public GenderType Gender {get;set;}
         [DisplayName("Marital Status")]
        [Required]
        public MaritalStatusType MaritalStatus {get;set;}
        [Required]
        public string Email {get;set;}
         [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber {get;set;}
        [DisplayName("Change Password")]
        public string? PassWord {get;set;}
        [DisplayName("Account Number")]
        public string AccountNumber {get; set;}
        [Required]
        public string Pin           {get; set;}
         [DisplayName("Account Type")]
        [Required]
        public AccountType AccountType   {get; set;}
        [DisplayName("Account Balance")]
        [Required]
        public double AccountBalance {get; set;}
         public bool IsActive {get;set;} 
        public DateTime DateCreated {get; set;} 
    }
}