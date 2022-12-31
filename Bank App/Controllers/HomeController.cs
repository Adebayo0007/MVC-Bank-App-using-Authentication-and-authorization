using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private readonly IUserService _service;

    public HomeController(ILogger<HomeController> logger,IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
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
            var user = _service.Login(email,passWord);
            if (user == null || user.IsActive == false)
            {
                 ViewBag.Error = "Invalid Email or PassWord";
                return View();
                
            }

            //session
        //     HttpContext.Session.SetString("Email", customer.Email);
        //    HttpContext.Session.SetString("PassWord", customer.PassWord);
        //     return RedirectToAction(nameof(ManageTransaction));



              //cookies

            var roles = new List<string>();
            var claims = new List<Claim>
            {
                // new Claim(ClaimTypes.Name , user.Id + " " +user.Id),
                //new Claim(ClaimTypes.Name , lecturer.LastName + " " +lecturer.FirstName),
                new Claim(ClaimTypes.Email , user.Email),
                 new Claim(ClaimTypes.Name , user.PassWord),
                 new Claim(ClaimTypes.NameIdentifier , (user.Role == "Customer") ? user.Customer.AccountNumber:""),
                    // new Claim(ClaimTypes.NameIdentifier , (user.Role == "Manager") ? user.Manager.ManagerId:""),
                    
                new Claim(ClaimTypes.Role , (user.Role == "Customer") ? "Customer":""),
                new Claim(ClaimTypes.Role , (user.Role == "Admin") ? "Admin":""),
                 new Claim(ClaimTypes.Role , (user.Role == "Manager") ? "Manager":""),
                  new Claim(ClaimTypes.Role , (user.Role == "CEO") ? "CEO":""),
                // new Claim(ClaimTypes.NameIdentifier , 2.ToString()),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString())
        
            };

            var claimsIdentity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal, authenticationProperties);

            // foreach(var item in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role , item));
            // }
             if(user.Role == "CEO")
            {
                TempData["success"] = "Login Successfully";
                 return RedirectToAction("ManageManagers", "CEO");

            }
             if(user.Role == "Manager")
            {
                TempData["success"] = "Login Successfully";
                 return RedirectToAction("ManageAdmins", "Manager");

            }
            if(user.Role == "Admin")
            {
                TempData["success"] = "Login Successfully";
                 return RedirectToAction("ManageCustomer", "Admin");

            }
             if(user.Role == "Customer")
            {
                TempData["success"] = "Login Successfully";
                 return RedirectToAction("ManageTransaction", "Customer");

            }
            return RedirectToAction(nameof(Index));
            
        }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
