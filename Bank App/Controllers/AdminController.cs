using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.RequestModel;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }
        //  [Authorize(Roles = "Admin,Manager,CEO")]
        [HttpGet]
        public IActionResult IndexPage()
        {
            return View();
        }
           [Authorize(Roles = "Admin, Manager, CEO,User")]
          public IActionResult ManageCustomer()
        {
            return View();
        }
        [Authorize(Roles = "Manager,CEO,User")]
        public IActionResult CreateAdmin()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateAdmin(AdminRequestModel admin)
        {
            if(admin != null)
            {
                _service.CreateAdmin(admin);
                TempData["success"] = "Admin Created Successfully";
                return RedirectToAction(nameof(IndexPage));
            }
            else
            {
                ViewBag.Error = "Wrong Input";
               return View();
            }

           
            
        }
         [Authorize(Roles = "Manager, CEO, User")]
        // [HttpGet]
         public IActionResult DeleteAdmin(string staffId)
        {       
            // if(staffId == null)
            // {
            //     return NotFound();
            // }
            var admin = _service.GetAdminById(staffId);
            // if(admin == null)
            // {
            //     return NotFound();
            // }

            //  if(staffId == null)
            // {
            //     return NotFound();
            // }
            // var admin = _service.GetAdminById(staffId);
            // if(admin == null)
            // {
            //     return NotFound();
            // }

            return View(admin);          
        }
         [Authorize]
        [HttpPost , ActionName("DeleteAdmin")]
        [ValidateAntiForgeryToken]
         public IActionResult DeleteAdminConfirmed(string staffId)
        {
            _service.DeleteAdminUsingId(staffId);
            return RedirectToAction(nameof(Admins));
        }
          [Authorize(Roles = "Manager, CEO, User")]
          [HttpGet]
         public IActionResult UpdateAdmin(string staffId)
        {       
            if(staffId == null)
            {
                return NotFound();
            }
            var admin = _service.GetAdminById(staffId);
            if(admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }
           [Authorize]
        [HttpPost , ActionName("UpdateAdmin")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateAdmin(AdminUpdateRequestModel admin)
        {
            _service.UpdateAdmin(admin);
            return RedirectToAction(nameof(Admins));
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
            var admin = _service.Login(email,passWord);
            if (admin == null)
            {
                //  ViewBag.Error = "Invalid Email or PassWord";
                // return View();
                return NotFound();
            }
            // else
            // {
            // return RedirectToAction(nameof(ManageCustomer));
            // }
           

        //    //session
        //    HttpContext.Session.SetString("Email", admin.Email);
        //    HttpContext.Session.SetString("PassWord", admin.PassWord);
        //     return RedirectToAction(nameof(ManageCustomer));


        //cookies

         var roles = new List<string>();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , admin.LastName + " " +admin.FirstName),
                //new Claim(ClaimTypes.Name , lecturer.LastName + " " +lecturer.FirstName),
                new Claim(ClaimTypes.Email , admin.Email),
                new Claim(ClaimTypes.Role , "Admin"),
                // new Claim(ClaimTypes.NameIdentifier , 2.ToString()),
                new Claim(ClaimTypes.NameIdentifier , admin.StaffId)
        
            };

            var claimsIdentity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal, authenticationProperties);

            // foreach(var item in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role , item));
            // }
           return RedirectToAction(nameof(ManageCustomer));
           
            
        }


          [Authorize(Roles = "Manager, CEO, User")] 
         public IActionResult Admins()
        {
            var admins = _service.GetAllAdmin();
            return View(admins);
        }

        //  [HttpGet("{staffId}")]
        //  public IActionResult Details([FromQuery] Admin admin)
        // {
             
        //     var adminn = _service.GetAdminById(admin);
        //     return View(adminn);
        //     // return RedirectToAction(nameof(Admins));
        // }
           [Authorize(Roles = "Manager, CEO, User")]
          [HttpGet("{staffId}")]
         public IActionResult Details([FromRoute]string staffId)
        {       
            
            // var admin = _service.GetAdminById(staffId);
            // return View(admin);


            //session
            //  if(HttpContext.Session.GetString("Email")== null)
            // {
            //     return BadRequest();
            // }
            var admin = _service.GetAdminById(staffId);
          
            return View(admin);
        }



        
    }
}