using Bank_App.Models;
using Bank_App.Models.Enum;
using MobileBankApp;
using MobileBankApp.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_MobileBankApp.Models

{
    public class User
    {
        public int Id {get; set;}
         public string Email {get; set;}
         public Customer Customer{get; set;} = null;
         public Admin Admin {get; set;} =  null;
         public Manager Manager {get; set;}  = null;
         public CEO Ceo {get; set;}
          public bool IsActive {get;set;} 
          public string PassWord {get; set;}
           public string Role {get; set;}
          

    }
}