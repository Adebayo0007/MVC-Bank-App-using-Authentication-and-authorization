using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.Enum;

namespace MVC_MobileBankApp.Models

{
   
    // [Index(nameof(Email), IsUnique = true)]
    public class Admin 
    {
           
        [DisplayName("First Name")]
        [Required(ErrorMessage = "The Admin's name is required")]
        public string FirstName {get;set;}
        [DisplayName("Last Name")]
        [Required]
        public string LastName {get;set;}
        [DisplayName("Profile Picture")]
        [Required]
        public byte[]? ProfilePicture {get; set;}
        [Required]
        public string Address {get;set;}
        public int ManagerId {get; set;}

        public int UserId {get;set;}
        [Key]
        public string StaffId  {get; set;}
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
          public int ManagerPass {get;set;}
         public DateTime DateCreated {get; set;} = DateTime.Now;
         
        
        
    }    
}