using System.ComponentModel.DataAnnotations;
namespace MVC_MobileBankApp.Models

{
    // [Index(nameof(Email), IsUnique = true)]
    public class Admin : BaseClass
    {
        public int ManagerId {get; set;}
        [Key]
        public string StaffId  {get; set;}
         public int ManagerPass {get;set;}
        
    }    
}