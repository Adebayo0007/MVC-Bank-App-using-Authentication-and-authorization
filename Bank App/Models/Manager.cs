using System.ComponentModel.DataAnnotations;
namespace MVC_MobileBankApp.Models

{
     //[Index(nameof(Email), IsUnique = true)]
    public class Manager : BaseClass
    {
        
        [Key]
        public string ManagerId  {get; set;}
         public int AdminRegistrationCode {get;set;} 
         public List<Admin> Admins = new List<Admin>();     
        
    }    
}