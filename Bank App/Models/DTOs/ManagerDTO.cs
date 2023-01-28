using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;

namespace MVC_MobileBankApp.Models.DTOs
{
    public class ManagerDTO
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Address {get;set;}
        public int UserId {get;set;}
        public string ManagerId  {get; set;} 
        [DisplayName("Date Of Birth")] 
        [Required]
         public DateTime DOB  {get; set;}    
        public int Age {get;set;}
        [Required]
        public GenderType Gender {get;set;}
        [DisplayName("Marital Status")]
        [Required]
        public MaritalStatusType MaritalStatus {get;set;}
         [EmailAddress]
        [Required]
        public string Email {get;set;}
        [DisplayName("Confirm Email")]
        [Compare("Email")]
        public string ConfirmEmail {get;set;}
         [DisplayName("Phone Number")]
         [Phone]
        [Required]
        public string PhoneNumber {get;set;}
        [DisplayName("Password")]
        [Required]
        public string PassWord {get;set;}
        public bool IsActive {get;set;} 
        public int AdminRegistrationCode {get;set;} 
        public List<Admin> Admins = new List<Admin>();
        public string? Message {get; set;}
        public DateTime DateCreated {get; set;} = DateTime.Now;
        
    }



         public class ManagerRequestModel
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Address {get;set;}
        public int UserId {get;set;}
        public string ManagerId  {get; set;}   
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
        public int AdminRegistrationCode {get;set;} 
        public List<Admin> Admins = new List<Admin>();
        public string? Message {get; set;}
        public DateTime DateCreated {get; set;}


    }
}