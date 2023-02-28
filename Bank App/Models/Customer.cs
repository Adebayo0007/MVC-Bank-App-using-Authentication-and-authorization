using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models
{
     //[Index(nameof(Email), IsUnique = true)]
    public class Customer 
    {
        
        public AccountType AccountType   {get; set;}
        public double AccountBalance {get; set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public byte[]? ProfilePicture {get; set;}
        public string Address {get;set;}
        public int UserId {get;set;}
         [Key]
        public string AccountNumber {get; set;}
        public string Pin           {get; set;}
        public int Age {get;set;}
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string PassWord {get;set;}
         public bool IsActive {get;set;} 
        public DateTime DateCreated {get; set;} 
        
    }
}