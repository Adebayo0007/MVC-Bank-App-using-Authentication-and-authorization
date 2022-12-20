using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
{
    public class UserController : Controller
    {
         private readonly IUserService _userService;
         private readonly ICustomerService _customerService;
         private readonly IAdminService _adminService;
         private readonly IManagerService _managerService;
         private readonly ICEOService _ceoService;
        public UserController(IUserService userService,ICustomerService customerService,IAdminService adminService,IManagerService managerService,ICEOService ceoService)
        {
            _userService = userService;
            _customerService = customerService;
            _adminService = adminService;
            _managerService = managerService;
            _ceoService = ceoService;
        }
        //   public IActionResult LogIn()
        // {
        //    return View();
           
        // }

        // [HttpPost , ActionName("LogIn")]
        //  public IActionResult LogInConfirmed(string email,string passWord)
        // {
        //     if(email == null || passWord == null)
        //     {
        //         return NotFound();
        //     }
        //     var user = _userService.Login(email,passWord);
        //     if (user == null)
        //     {
        //          ViewBag.Error = "Invalid Email or PassWord";
        //         return View();
        //     }
        //     else
        //     {
        //     return RedirectToAction(nameof(ManageTransaction));
        //     }
           
            
        // }


    }
}