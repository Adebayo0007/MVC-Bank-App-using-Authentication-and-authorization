using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class CustomerController : Controller
    {
         private readonly ICustomerService _service;
         private readonly ITransactionService _transactionService;
         private readonly IUserService _userService;

        public CustomerController(ICustomerService service, ITransactionService transactionService, IUserService userService)
        {
            _service = service;
            _transactionService = transactionService;
            _userService = userService;
        }

       
        [HttpGet]
        public IActionResult CustomerIndexPage()
        {
            return View();
        }
         [Authorize(Roles = "Customer")]
         public IActionResult ManageTransaction()
        {
            return View();
        }

         [Authorize(Roles = "Customer")]
         public IActionResult Template()
        {
            return View();
        }

          [Authorize(Roles = "Customer")]
         public IActionResult Card()
        {
            string accNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
               string first = User.FindFirst(ClaimTypes.Country).Value;
               string last = User.FindFirst(ClaimTypes.CookiePath).Value;
            TempData["acc"] = accNumber;
             TempData["first"] = first;
              TempData["last"] = last ;
            return View();
        }
      
        public IActionResult CreateCustomer()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateCustomer(CustomerDTO customer)
        {
             var user = _userService.GetUserByEmail(customer.Email);
           if(user == null)
           {
            if(customer != null)
            {
                  //profile pix
                  try{

                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        using (var dataStream = new MemoryStream())
                        {
                           file.CopyToAsync(dataStream);
                            customer.ProfilePicture = dataStream.ToArray();
                        }
                  }
                  catch(Exception ex)
                  {
                    var mess = ex.Message.ToString();
                                         TempData["pix"] = $"Profile picture is required";
                                    TempData.Keep();
                                    return View();

                  }
                // if(customer.ProfilePicture == null)
                // {
                //      TempData["pix"] = "Profile Picture can not be empty";
                //       TempData.Keep();
                //      return View();
                // }

                
               var inner =  _service.CreateCustomer(customer);
                if(inner.Message == null)
                {
                 TempData["success"] = $"{customer.FirstName} {customer.LastName} Created Successfully";
                TempData.Keep();
                return RedirectToAction("LogIn", "Home");
                }
                else
                {
                  TempData["age"] = inner.Message;
                TempData.Keep();
                return View();
                }

            }
            else
            {
                TempData["error"] = "Wrong Input";
               return View();
            }
           }
             else
           {
           
                TempData["exist"] = $" Dear Mr/Mrs {customer.FirstName} {customer.LastName}!\\n Go to your Profile to Update your Profile";
                TempData.Keep();
                return View();

           }
            
            
        }

         [Authorize(Roles = "Admin, Manager, CEO")]
         public IActionResult DeleteCustomer(string accountNumber)
        {       
            var admin = _service.GetCustomerByAccountnumber(accountNumber);
            return View(admin);          
        }

         [Authorize]
        [HttpPost , ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
         public IActionResult DeleteCustomerConfirmed(string accountNumber)
        {
             _service.DeleteCustomer(accountNumber);
            return RedirectToAction(nameof(Customers));
        }

        [Authorize(Roles = "Admin,Manager, CEO")]
        [HttpGet]
         public IActionResult UpdateCustomer(string accountNumber)
        {       
            if(accountNumber == null)
            {
                return NotFound();
            }
            var customer = _service.GetCustomerByAccountnumber(accountNumber);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [Authorize]
        [HttpPost , ActionName("UpdateCustomer")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateCustomer(CustomerRequestModel customer)
        {
            _service.UpdateCustomer(customer);
            return RedirectToAction(nameof(Customers)); 
            // return RedirectToAction(nameof(Customers), new Object{id = customer});
        }


         [Authorize(Roles = "Admin,Manager, CEO")]
         public IActionResult Customers()
        {
            var customers =  _service.GetAllCustomer();
            var customer =  _service.NumberOfCustomer();
             TempData["customers"] = customer;
                TempData.Keep();
            return View(customers);
        }


        [Authorize(Roles = "Customer,Admin,Manager, CEO")]
          [HttpGet]
         public IActionResult Details(string accountNumber)
        {   

        //  if(HttpContext.Session.GetString("Email")== null)
        //     {
        //         return BadRequest();
        //     }     
            var customer =_service.GetCustomerByAccountnumber(accountNumber);
            return View(customer);
        }
        [Authorize(Roles="Customer")]
        [HttpGet]
        public IActionResult Profile(string accountNumber)
        {
            accountNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var customerProfile = _service.GetCustomerByAccountnumber(accountNumber);
            return View(customerProfile);

        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
         public IActionResult UpdateProfile(string accountNumber)
        {       
            accountNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(accountNumber == null)
            {
                return NotFound();
            }
            var customer = _service.GetCustomerByAccountnumber(accountNumber);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [Authorize]
        [HttpPost , ActionName("UpdateProfile")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateProfile(CustomerRequestModel customer)
        {
            _service.UpdateCustomer(customer);
            return RedirectToAction(nameof(Profile));
        }


        [Authorize(Roles = "Customer")]
         public IActionResult CustomerTransactions(string  accountNumber)
        {
            accountNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transaction = _transactionService.GetAllTransactionUsingAccountNumber(accountNumber);
            return View(transaction);
            
        }

        [Authorize(Roles = "Customer")]
         public IActionResult Reciept(string  accountNumber)
        {
            accountNumber = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var customer =_transactionService.GetTransactionByAccount(accountNumber);
            return View(customer);
            
        }



        



    }
}