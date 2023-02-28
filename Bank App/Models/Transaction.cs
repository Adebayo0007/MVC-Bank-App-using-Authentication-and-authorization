using MVC_MobileBankApp.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_MobileBankApp.Models

{
    public class Transaction
    {
        [Key]
        public string RefNum{get;set;}
        public TransactionType TransactType {get; set;}
        public string? Description {get;set;}
        
        [ForeignKey("AccountNumber")]
        public string AccountNumber{get;set;}
        public Customer Customer {get;set;}
        public double Amount{get;set;}
        public string Pin{get;set;}
        public double AccountBalance{get;set;}
        public string DateCreated {get;set;} 
        public string? RecipientAccountNumber {get; set;}
    }
}