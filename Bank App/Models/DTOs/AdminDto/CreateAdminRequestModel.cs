using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;

namespace MVC_MobileBankApp.Models.DTOs.AdminDto
{
    public class CreateAdminRequestModel
    {
        
        [DisplayName("First Name")]
        [Required(ErrorMessage = "The Admin's name is required")]
        [StringLength(225)]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        
        [DisplayName("Profile Picture")]
        [Required]
        public byte[]? ProfilePicture {get; set;}
        [Required]
        public string Address {get;set;}
        [DisplayName("Date Of Birth")] 
        [Required]
        public DateTime DOB  {get; set;}
        // [Range(1,200)]
        // public int Age {get;set;}
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
         public int ManagerPass {get;set;}
        public string? Message { get; set;}
        // public DateTime DateCreated {get; set;} = DateTime.Now;
        
    }
}