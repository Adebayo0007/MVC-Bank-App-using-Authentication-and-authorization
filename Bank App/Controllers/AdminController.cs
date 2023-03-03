using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.AdminDto;
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
         public IActionResult CreateAdmin(CreateAdminRequestModel admin)
        {
             admin.ManagerPass = int.Parse(User.FindFirst(ClaimTypes.Hash).Value);
           var user = _userService.GetUserByEmail(admin.Email);
           if(user == false)
           {
             var adminn = _managerService.Code(admin.ManagerPass);
           if(adminn == null)
           {
              TempData["error"] = "You are not authorize to create admin";
              TempData.Keep();
               return View();
           }

            if(admin != null)
            {
                 //profile pix
                    try{

                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        using (var dataStream = new MemoryStream())
                        {
                          file.CopyToAsync(dataStream);
                            admin.ProfilePicture = dataStream.ToArray();
                        }
                  }
                  catch(Exception ex)
                  {
                                          var mess = ex.Message.ToString();
                                            // TempData["pix"] = mess;
                                         TempData["pix"] = $"Profile picture is required";
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
         public IActionResult UpdateAdmin(UpdateAdminRequestModel admin)
        {
            _service.UpdateAdmin(admin);
            return RedirectToAction("MyAdmins", "Manager");
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
            var adminProfile =  _service.GetAdminById(staffId);
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
         public IActionResult UpdateProfile(UpdateAdminRequestModel admin)
        {
             _service.UpdateAdmin(admin);
            return RedirectToAction(nameof(Profile));
        }
    
    }
}