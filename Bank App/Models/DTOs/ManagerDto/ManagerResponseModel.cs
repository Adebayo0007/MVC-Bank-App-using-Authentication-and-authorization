using System.ComponentModel;
using MVC_MobileBankApp.Enum;

namespace MVC_MobileBankApp.Models.DTOs.ManagerDto
{
    public class ManagerResponseModel
    {
         [DisplayName("First Name")]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        public string LastName {get;set;}
        [DisplayName("Profile Picture")]
        public byte[]? ProfilePicture {get; set;}
        public string Address {get;set;}
        public string ManagerId  {get; set;}
        public int Age {get;set;}
        public GenderType Gender {get;set;}
         [DisplayName("Marital Status")]
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
         [DisplayName("Phone Number")]
        public string PhoneNumber {get;set;}
        [DisplayName("Password")]
        public string PassWord {get;set;}
         public bool IsActive {get;set;} 
          public int AdminRegistrationCode {get;set;} 
        public DateTime DateCreated {get; set;} 
        
    }
}