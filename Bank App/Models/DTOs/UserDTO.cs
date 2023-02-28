using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Models.DTOs
{
    public class UserDTO
    {
         public int Id {get; set;}
         public string Email {get; set;}
          public bool IsActive {get;set;} 
          public string PassWord {get; set;}
           public string Role {get; set;}
           public string Message {get; set;}
        
    }
   
}