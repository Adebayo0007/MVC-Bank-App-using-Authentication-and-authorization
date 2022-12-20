using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
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

        [Authorize(Roles = "Admin, Manager, CEO, User")]
         [HttpGet]
        public IActionResult IndexTransactionPage()
        {
            return View();
        }
         [Authorize(Roles = "Customer, User")]
        public IActionResult CreateTransaction()
        {
            return View();
        }
          [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateTransaction(Transaction transaction)
        {
            transaction.AccountNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(transaction != null)
            {
                var transact = _transactionService.CreateTransaction(transaction);
                if(transact != null)
                {
                    TempData["success"] = "Transaction Successfully";
                    TempData.Peek("success");
                }
                else
                {
                   TempData["error"] = "Invalid Transaction"; 
                   TempData.Peek("error");
                }
                return RedirectToAction("ManageTransaction", "Customer");
            }
            else
            {
                // ViewBag.Error = "Wrong Input";
                 TempData["error"] = "Invalid Transaction"; 
                 TempData.Peek("error");
               return View();
            }
        }

        [Authorize(Roles = "Admin,Manager, CEO, User")]
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
         [Authorize(Roles = "Admin,Manager, CEO, User")]
         public IActionResult Transactions()
        {
            var transaction = _transactionService.GetAllTransaction ();
            return View(transaction);
        }
         [Authorize(Roles = "Admin,Manager, CEO, User")]
         public IActionResult GetAccountTransactions(string  accountNumber)
        {
            var transaction = _transactionService.GetAllTransactionUsingAccountNumber(accountNumber);
            return View(transaction);
            
        }

          [Authorize(Roles = "Admin,Manager, CEO, User")]
         public IActionResult TransactionDetails(string refNum)
        {       
            
            var transaction = _transactionService.GetTransactionByRefNum(refNum);
            return View(transaction);
        }


        
    }
}