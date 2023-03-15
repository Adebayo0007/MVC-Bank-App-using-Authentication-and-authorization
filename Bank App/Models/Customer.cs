using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_MobileBankApp.Enum;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models
{
     //[Index(nameof(Email), IsUnique = true)]
    public class Customer : BaseClass
    {

        public AccountType AccountType   {get; set;}
        public double AccountBalance {get; set;}
        public int UserId {get;set;}
         [Key]
        public string AccountNumber {get; set;}
        public string Pin           {get; set;}
    
          
    }
}