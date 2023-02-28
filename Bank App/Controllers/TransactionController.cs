using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class TransactionController : Controller
    {
         private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        
        }

        [Authorize(Roles = "Admin, Manager, CEO")]
         [HttpGet]
        public IActionResult IndexTransactionPage()
        {
            return View();
        }
         [Authorize(Roles = "Customer")]
        public IActionResult CreateTransaction()
        {
            return View();
        }
          [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateTransaction(TransactionDTO transaction)
        {
            transaction.AccountNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // var transac = _transactionService.CreateTransaction(transaction);
                var transact = _transactionService.CreateTransaction(transaction);
            if(transact.Message != null )
            {
               TempData["message"] = transaction.Message; 
                 TempData.Keep();
               return View();
                    
            }
            else
            {
                // ViewBag.Error = "Wrong Input";
                TempData["message"] = $"Transaction Successful\\n {transact.SuccessMessage}";
                    TempData.Keep("message");
                //      var reciever = new List<string>{"milajack5864@gmail.com","johnwilson5864@gmail.com", "tijaniadebayoabdllahi@gmail.com"};
                //  Email.SendMail("tijaniadebayoabdllahi@gmail.com",null, reciever,null,null,transact.SuccessMessage,"Transaction Reciept",null,null );
                     return RedirectToAction("Reciept", "Customer");
                     
                     
                 
            }
        }

        // [Authorize(Roles = "Admin,Manager, CEO, User")]
        //  public IActionResult DeleteTransaction(string refNum)
        // {            
        //     var transaction = _transactionService.GetTransactionByRefNum(refNum);
        //     return View(transaction);          
        // }
        //   [Authorize]
        // [HttpPost , ActionName("DeleteTransaction")]
        // [ValidateAntiForgeryToken]
        //  public IActionResult DeleteTransactionConfirmed(string refNum)
        // {
        //     _transactionService.DeleteTransactionUsingRefNum(refNum);
        //     return RedirectToAction(nameof(Transactions));
        // }
         [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult Transactions()
        {
            var transaction = _transactionService.GetAllTransaction ();
            return View(transaction);
        }
         [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult GetAccountTransactions(string  accountNumber)
        {
            var transaction =  _transactionService.GetAllTransactionUsingAccountNumber(accountNumber);
            return View(transaction);
            
        }
         
          [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult TransactionDetails(string refNum)
        {       
            
            var transaction = _transactionService.GetTransactionByRefNum(refNum);
            
            return View(transaction);
        }


        
    }
}