using MVC_MobileBankApp.Enum;

namespace MVC_MobileBankApp
{
    public class BaseClass
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public byte[]? ProfilePicture {get; set;}
        public string Address {get;set;}
         public int UserId {get;set;}
        public int Age {get;set;}
        public GenderType Gender {get;set;}
        public MaritalStatusType MaritalStatus {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        //  public string PassWord {get;set;}
         public bool IsActive {get;set;} 
        public DateTime DateCreated {get; set;} 
        
    }
}