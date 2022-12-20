using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class ManagerController : Controller
    {
         private readonly IManagerService _service;

        public ManagerController(IManagerService service)
        {
            _service = service;
        }
        //   [Authorize(Roles = "Manager, CEO")] 
        [HttpGet]
        public IActionResult IndexManagerPage()
        {
            return View();
        }
          [Authorize(Roles = "Manager, CEO, User")] 
          public IActionResult ManageAdmins()
        {
            return View();
        }
          [Authorize(Roles = "CEO, User")] 
        public IActionResult CreateManager()
        {
            return View();
        }
           [Authorize] 
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateManager(ManagerDTO manager)
        {
            if(manager != null)
            {
                _service.CreateManager(manager);
                TempData["success"] = "Manager Created Successfully";
                return RedirectToAction(nameof(IndexManagerPage));
            }
            else
            {
                // ViewBag.Error = "Wrong Input";
                 TempData["error"] = "wrong input"; 
               return View();
            }
        }

           [Authorize(Roles = "CEO, User")] 
         public IActionResult DeleteManager(string managerId)
        {            
            var manager = _service.GetManagerById(managerId);
            return View(manager);          
        }

        [Authorize] 
        [HttpPost , ActionName("DeleteManager")]
        [ValidateAntiForgeryToken]
         public IActionResult DeleteManagerConfirmed(string managerId)
        {
            _service.DeleteManager(managerId);
            return RedirectToAction(nameof(Managers));
        }
            [Authorize(Roles = "CEO, User")] 
          [HttpGet]
         public IActionResult UpdateManager(string managerId)
        {       
            if(managerId == null)
            {
                return NotFound();
            }
            var manager = _service.GetManagerById(managerId);
            if(manager == null)
            {
                 TempData["error"] = "Not found"; 
                return NotFound();
            }
            return View(manager);
        }

        [Authorize] 
        [HttpPost , ActionName("UpdateManager")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateManager(ManagerRequestModel manager)
        {
            _service.UpdateManager(manager);
            return RedirectToAction(nameof(Managers));
        }


         public IActionResult LogInManager()
        {
           return View();
           
        }

        [HttpPost , ActionName("LogInManager")]
         public IActionResult LogInConfirmed(string email,string passWord)
        {
            if(email == null || passWord == null)
            {
                return NotFound();
            }
            var manager = _service.Login(email,passWord);
            if (manager == null)
            {
                //  ViewBag.Error = "Invalid Email or PassWord";
                return NotFound();
            }
            // else
            // {
            // return RedirectToAction(nameof(ManageAdmins));
            // }


            //session

            //   HttpContext.Session.SetString("Email", manager.Email);
            //    HttpContext.Session.SetString("PassWord", manager.PassWord);
            //    return RedirectToAction(nameof(ManageAdmins));


              //cookies

               var roles = new List<string>();
              var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , manager.LastName + " " +manager.FirstName),
                //new Claim(ClaimTypes.Name , lecturer.LastName + " " +lecturer.FirstName),
                new Claim(ClaimTypes.Email , manager.Email),
                new Claim(ClaimTypes.Role , "Manager"),
                // new Claim(ClaimTypes.NameIdentifier , 2.ToString()),
                new Claim(ClaimTypes.NameIdentifier , manager.ManagerId)
        
            };

            var claimsIdentity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal, authenticationProperties);

            // foreach(var item in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role , item));
            // }
            return RedirectToAction(nameof(ManageAdmins));
            
           
            
        }


           [Authorize(Roles = "CEO, User")] 
         public IActionResult Managers()
        {
            var managers = _service.GetAllManager();
            return View(managers);
        }

           [Authorize(Roles = "CEO, User")] 
         public IActionResult ManagerDetails(string managerId)
        {       
            
            var manager = _service.GetManagerById(managerId);
            return View(manager);
        }


        
    }
}