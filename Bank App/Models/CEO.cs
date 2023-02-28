using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.Enum;
using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Models
{
    // [Index(nameof(Email), IsUnique = true)]
    public class CEO
    {
        
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
        public int UserId {get;set;}
        public string CEOId  {get; set;}
        public int Age {get;set;}
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string PassWord {get;set;}
        public bool IsActive {get;set;} 
        public DateTime DateCreated {get; set;} = DateTime.Now;
        
    }
}