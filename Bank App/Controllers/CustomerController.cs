using System.Security.Claims;
using Bank_App.Models;
using Bank_App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;

namespace Bank_App.Controllers
{
    public class CustomerController : Controller
    {
         private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

       
        [HttpGet]
        public IActionResult CustomerIndexPage()
        {
            return View();
        }
         [Authorize(Roles = "Customer,User")]
         public IActionResult ManageTransaction()
        {
            return View();
        }
      
        public IActionResult CreateCustomer()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateCustomer(Customer customer)
        {
            if(customer != null)
            {
                _service.CreateCustomer(customer);
                TempData["success"] = "Registration Successfully";
                return RedirectToAction(nameof(CustomerIndexPage));
            }
            else
            {
                ViewBag.Error = "Wrong Input";
               return View();
            }

           
            
        }
         [Authorize(Roles = "Admin,Manager, CEO, User")]
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
           [Authorize(Roles = "Admin,Manager, CEO, User")]
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
         public IActionResult UpdateCustomer(Customer customer)
        {
            _service.UpdateCustomer(customer);
            return RedirectToAction(nameof(Customers));

            
            // return RedirectToAction(nameof(Customers), new Object{id = customer});
        }


         public IActionResult LogIn()
        {
           return View();
           
        }

        [HttpPost , ActionName("LogIn")]
         public IActionResult LogInConfirmed(string email,string passWord)
        {
            if(email == null || passWord == null)
            {
                return NotFound();
            }
            var customer = _service.Login(email,passWord);
            if (customer == null)
            {
                //  ViewBag.Error = "Invalid Email or PassWord";
                return NotFound();
            }
            // else
            // {
            // return RedirectToAction(nameof(ManageTransaction));
            // }

            //session
        //     HttpContext.Session.SetString("Email", customer.Email);
        //    HttpContext.Session.SetString("PassWord", customer.PassWord);
        //     return RedirectToAction(nameof(ManageTransaction));

        //cookies

          //cookies

         var roles = new List<string>();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , customer.LastName + " " +customer.FirstName),
                //new Claim(ClaimTypes.Name , lecturer.LastName + " " +lecturer.FirstName),
                new Claim(ClaimTypes.Email , customer.Email),
                new Claim(ClaimTypes.Role , "Customer"),
                // new Claim(ClaimTypes.NameIdentifier , 2.ToString()),
                new Claim(ClaimTypes.NameIdentifier , customer.AccountNumber)
        
            };

            var claimsIdentity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal, authenticationProperties);

            // foreach(var item in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role , item));
            // }
            return RedirectToAction(nameof(ManageTransaction));
            
        }
         [Authorize(Roles = "Admin,Manager, CEO, User")]
         public IActionResult Customers()
        {
            var customers = _service.GetAllCustomer();
            return View(customers);
        }

        [Authorize(Roles = "Customer,Admin,Manager, CEO, User")]

          [HttpGet]
         public IActionResult Details(string accountNumber)
        {   

        //  if(HttpContext.Session.GetString("Email")== null)
        //     {
        //         return BadRequest();
        //     }     
            var customer = _service.GetCustomerByAccountnumber(accountNumber);
            return View(customer);
        }



    }
}