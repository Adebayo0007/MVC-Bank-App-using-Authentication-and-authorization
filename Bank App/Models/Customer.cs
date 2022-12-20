using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models
{
    public class Customer
    {
        
    
        [DisplayName("Account Type")]
        [Required]
        public AccountType AccountType   {get; set;}
        [DisplayName("Account Balance")]
        [Required]
        public double AccountBalance {get; set;}
         [DisplayName("First Name")]
        [Required]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Address {get;set;}
        public int UserId {get;set;}
         [Key]
         [DisplayName("Account Number")]
        public string AccountNumber {get; set;}
        [Required]
        public string Pin           {get; set;}
         [Required]
        public int Age {get;set;}
        [Required]
        public GenderType Gender {get;set;}
         [DisplayName("Marital Status")]
        [Required]
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
         [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber {get;set;}
        [DisplayName("Password")]
        [Required]
        public string PassWord {get;set;}
         public bool IsActive {get;set;} 
        public DateTime DateCreated {get; set;} = DateTime.Now;
        
    }
}