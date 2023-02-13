using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        private readonly IManagerService _managerService;
         private readonly IUserService _userService;

        public AdminController(IAdminService service, IManagerService managerService,IUserService userService)
        {
            _service = service;
            _managerService = managerService;
            _userService = userService;
        }
        //  [Authorize(Roles = "Admin,Manager,CEO")]
        [HttpGet]
        public IActionResult IndexPage()
        {
            return View();
        }
           [Authorize(Roles = "Admin, Manager, CEO")]
          public IActionResult ManageCustomer()
        {
            return View();
        }
        [Authorize(Roles = "Manager,CEO")]
        public IActionResult CreateAdmin()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateAdmin(AdminDTO admin)
        {
             admin.ManagerPass = int.Parse(User.FindFirst(ClaimTypes.Hash).Value);
           var user = _userService.GetUserByEmail(admin.Email);
           if(user == null)
           {
             var adminn = _managerService.Code(admin.ManagerPass);
           if(adminn == null)
           {
              TempData["error"] = "Wrong Pass Code";
              TempData.Keep();
               return View();
           }

            if(admin != null)
            {
                 //profile pix
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    file.CopyToAsync(dataStream);
                    admin.ProfilePicture = dataStream.ToArray();
                }
                
                if(admin.ProfilePicture == null)
                {
                     TempData["pix"] = "Profile Picture can not be empty";
                      TempData.Keep();
                     return View();
                }

                var check = _service.CreateAdmin(admin);
                if(check.Message == null)
                {
                   TempData["success"] = $"{admin.FirstName} {admin.LastName} Created Successfully";
                   TempData.Keep();
                    return RedirectToAction("LogIn", "Home");
                }
                else
                {
                      TempData["age"] = check.Message;
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
                TempData["exist"] = $" Dear Mr/Mrs {admin.FirstName} {admin.LastName}!\\n Go to your Profile to Update your Profile";
                TempData.Keep();
                return View();

           }
            
            //Validation condition

            // if(!ModelState.IsValid)
            // {
            //     return View("CreateAdmin", admin);
            // }
          
            
        }
         [Authorize(Roles = "Manager, CEO")]
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
            return RedirectToAction("MyAdmins", "Manager");
        }
          [Authorize(Roles = "Manager, CEO")]
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
         public IActionResult UpdateAdmin(AdminRequestModel admin)
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


          [Authorize(Roles = "Manager, CEO")] 
         public IActionResult Admins()
        {
            var admins = _service.GetAllAdmin(); 
            string value = _service.NumberOfAdmin();
            TempData["admins"] = value;
                TempData.Keep();
            return View(admins);
        }

        //  [HttpGet("{staffId}")]
        //  public IActionResult Details([FromQuery] Admin admin)
        // {
             
        //     var adminn = _service.GetAdminById(admin);
        //     return View(adminn);
        //     // return RedirectToAction(nameof(Admins));
        // }
           [Authorize(Roles = "Manager, CEO")]
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


        [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult Profile(string staffId)
        {
            staffId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var adminProfile = _service.GetAdminById(staffId);
            return View(adminProfile);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
         public IActionResult UpdateProfile(string staffId)
        {       
            staffId = User.FindFirst(ClaimTypes.PrimarySid).Value;
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
        [HttpPost , ActionName("UpdateProfile")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateProfile(AdminRequestModel admin)
        {
            _service.UpdateAdmin(admin);
            return RedirectToAction(nameof(Profile));
        }
    
    }
}