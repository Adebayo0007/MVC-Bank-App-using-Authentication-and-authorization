using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private readonly IUserService _service;
       private readonly IAdminService _adminService;
       private readonly ICustomerService _customerService;
        private readonly IManagerService _managerService;

    public HomeController(ILogger<HomeController> logger,IUserService service, IAdminService adminService, ICustomerService customerService, IManagerService managerService)
    {
        _logger = logger;
        _service = service;
        _adminService = adminService;
        _customerService = customerService;
        _managerService = managerService;
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
            var admin = _adminService.GetAdminByEmail(user.Email);
            var customer = _customerService.GetCustomerByEmail(user.Email);
            var manager =  _managerService.GetManagerByEmail(user.Email);
            // if (user == null || user.IsActive == false)
            // {
            //       TempData["error"] = "Invalid Email or Password"; 
            //    return View();
                
            // }
            if(user.Message != null)
            {
                 TempData["logmessage"] = user.Message; 
                 TempData.Keep();
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
                 new Claim(ClaimTypes.NameIdentifier , (user.Role == "Customer") ? customer.AccountNumber:""),
                  new Claim(ClaimTypes.Country , (user.Role == "Customer") ? customer.FirstName:""),
                   new Claim(ClaimTypes.CookiePath , (user.Role == "Customer") ? customer.LastName:""),
                    new Claim(ClaimTypes.PrimarySid , (user.Role == "Admin") ? admin.StaffId:""),
                     new Claim(ClaimTypes.PrimaryGroupSid , (user.Role == "Manager") ? manager.ManagerId:""),
                      new Claim(ClaimTypes.Hash , (user.Role == "Manager") ? manager.AdminRegistrationCode.ToString():""),
                    //    new Claim(ClaimTypes.Dsa , (user.Role == "Manager") ? manager.ManagerId.ToString():""),

                    new Claim(ClaimTypes.Anonymous, (user.Role == "Customer") ? customer.ProfilePicture.ToString():""),
                   

             
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
         public async Task<IActionResult> LogOut(UserDTO request)
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
             TempData["success"] = $"{request.Email} Logged out Successfully";
                TempData.Keep();
            return RedirectToAction(nameof(LogIn));
        }

            [Authorize(Roles = "CEO")] 
         public IActionResult Users()
        {
            var users =  _service.GetAllUser();
            string user =  _service.NumberOfUsers();
             TempData["users"] = user;
                TempData.Keep();
            return View(users);
        }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
