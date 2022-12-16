using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MobileBankApp.Enum;
using MVC_MobileBankApp.Models;

namespace Bank_App.Models
{
    public class CEO
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
        [DisplayName("CEO ID")]
        [Key]
        public string CEOId  {get; set;}
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