using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models.DTOs
{
    public class TransactionDTO
    {
         
        [DisplayName("Ref Number")]
        public string RefNum{get;set;}
        [DisplayName("Transaction Type")]
         [Required]
        public TransactionType TransactType {get; set;}
        public string? Description {get;set;}

         [DisplayName("Account Number")]
        public string AccountNumber{get;set;}

        public Customer Customer {get;set;}
          [DisplayName("Amount (#)")]
         [Required]
        public double Amount{get;set;}
        [Required]
        public string Pin{get;set;}
         [DisplayName("Account Balance")]
        public double AccountBalance{get;set;}
         [DisplayName("Date Created")]
        public string DateCreated {get;set;} = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        public string? RecipientAccountNumber {get; set;}
        public string? Message {get; set;}
        public string? SuccessMessage {get; set;}
    }

         public class TransactionRequestModel
    {
          [DisplayName("Ref Number")]
        public string RefNum{get;set;}
        [DisplayName("Transaction Type")]
        public TransactionType TransactType {get; set;}
        public string Description {get;set;}

         [DisplayName("Account Number")]
        public string AccountNumber{get;set;}

        public Customer Customer {get;set;}
         [DisplayName("Account (#)")]
         [Required]
        public double Amount{get;set;}
        public string Pin{get;set;}
         [DisplayName("Account Balance")]
        public double AccountBalance{get;set;}
         [DisplayName("Date Created")]
        public string DateCreated {get;set;}
        public string? RecipientAccountNumber {get; set;}
    }
}