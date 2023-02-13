using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class ManagerController : Controller
    {
         private readonly IManagerService _service;
           private readonly IAdminService _adminService;
           private readonly IUserService _userService;

        public ManagerController(IManagerService service, IAdminService adminService, IUserService userService)
        {
            _service = service;
            _adminService = adminService;
            _userService = userService;
        }
        //   [Authorize(Roles = "Manager, CEO")] 
        [HttpGet]
        public IActionResult IndexManagerPage()
        {
            return View();
        }
          [Authorize(Roles = "Manager, CEO")] 
          public IActionResult ManageAdmins()
        {
            return View();
        }
          [Authorize(Roles = "CEO")] 
        public IActionResult CreateManager()
        {
            return View();
        }
           [Authorize] 
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateManager(ManagerDTO manager)
        {
              var user = _userService.GetUserByEmail(manager.Email);
           if(user == null)
           {
            if(manager != null)
            {
                  //profile pix
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    file.CopyToAsync(dataStream);
                    manager.ProfilePicture = dataStream.ToArray();
                }
                if(manager.ProfilePicture == null)
                {
                     TempData["pix"] = "Profile Picture can not be empty";
                      TempData.Keep();
                     return View();
                }

               var manage = _service.CreateManager(manager);
               if(manage.Message == null)
               {

              TempData["success"] = $"{manager.FirstName} {manager.LastName} Created Successfully";
              TempData["message"] = manage.Message;
                TempData.Keep();
                return RedirectToAction("LogIn", "Home");
               }
               else
               {
                
                      TempData["age"] = manage.Message;
                      TempData.Keep();
                     return View();

               }
            }
            else
            {
                // ViewBag.Error = "Wrong Input";
                 TempData["error"] = "wrong input"; 
               return View();
            }
           }
              else
           {
           
                TempData["exist"] = $" Dear Mr/Mrs {manager.FirstName} {manager.LastName}!\\n Go to your Profile to Update your Profile";
                TempData.Keep();
                return View();

           }
            

        }

           [Authorize(Roles = "CEO")] 
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
            [Authorize(Roles = "CEO")] 
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


           [Authorize(Roles = "CEO")] 
         public IActionResult Managers()
        {
            var managers = _service.GetAllManager();
            string manager = _service.NumberOfManager();
             TempData["managers"] = manager; 
            TempData.Keep();
            return View(managers);
        }

           [Authorize(Roles = "CEO")] 
         public IActionResult ManagerDetails(string managerId)
        {       
            
            var manager = _service.GetManagerById(managerId);
            return View(manager);
        }


        [Authorize(Roles="Manager")]
        [HttpGet]
        public IActionResult Profile(string managerId)
        {
            managerId = User.FindFirst(ClaimTypes.PrimaryGroupSid).Value;
            var managerProfile = _service.GetManagerById(managerId);
            return View(managerProfile);

        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
         public IActionResult UpdateProfile(string managerId)
        {       
            managerId = User.FindFirst(ClaimTypes.PrimaryGroupSid).Value;
            if(managerId == null)
            {
                return NotFound();
            }
            var manager = _service.GetManagerById(managerId);
            if(manager == null)
            {
                return NotFound();
            }
            return View(manager);
        }


        [Authorize]
        [HttpPost , ActionName("UpdateProfile")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateProfile(ManagerRequestModel manager)
        {
            _service.UpdateManager(manager);
            return RedirectToAction(nameof(Profile));
        }

         public IActionResult MyAdmins(string passCode)
         {
             passCode = User.FindFirst(ClaimTypes.Hash).Value;
              var admins =_adminService.GetAdmins(int.Parse(passCode));
            return View(admins);

         }


        



        
    }
}