using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;

namespace MVC_MobileBankApp.Models.DTOs.ManagerDto
{
    public class UpdateManagerRequestModel
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Address {get;set;}
        public string ManagerId  {get; set;}
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
        
    }
}