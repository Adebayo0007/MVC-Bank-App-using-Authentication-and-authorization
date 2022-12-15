using Bank_App.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
namespace Bank_App.Controllers
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
         public IActionResult CreateTransaction(Transaction transaction)
        {
            if(transaction != null)
            {
                var transact = _transactionService.CreateTransaction(transaction);
                if(transact != null)
                {
                    TempData["success"] = "Transaction Successfully";
                    TempData.Keep();
                }
                else
                {
                   TempData["invalid"] = "Invalid Transaction"; 
                   TempData.Keep();
                }
                return RedirectToAction("ManageTransaction", "Customer");
            }
            else
            {
                ViewBag.Error = "Wrong Input";
               return View();
            }
        }

        [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult DeleteTransaction(string refNum)
        {            
            var transaction = _transactionService.GetTransactionByRefNum(refNum);
            return View(transaction);          
        }
          [Authorize]
        [HttpPost , ActionName("DeleteTransaction")]
        [ValidateAntiForgeryToken]
         public IActionResult DeleteTransactionConfirmed(string refNum)
        {
            _transactionService.DeleteTransactionUsingRefNum(refNum);
            return RedirectToAction(nameof(Transactions));
        }
         [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult Transactions()
        {
            var transaction = _transactionService.GetAllTransaction ();
            return View(transaction);
        }
         [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult GetAccountTransactions(string  accountNumber)
        {
            var transaction = _transactionService.GetAllTransactionUsingAccountNumber(accountNumber);
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