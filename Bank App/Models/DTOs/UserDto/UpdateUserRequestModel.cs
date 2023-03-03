namespace MVC_MobileBankApp.Models.DTOs.UserDto
{
    public class UpdateUserRequestModel
    {
        public string Email {get; set;}
        public bool IsActive {get;set;} 
        public string PassWord {get; set;}
    }
}