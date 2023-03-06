namespace MVC_MobileBankApp.Models.DTOs
{
    public abstract class BaseResponse
    {
          public string Message{get; set;}
          public bool? Status {get; set;}
        
    }
}