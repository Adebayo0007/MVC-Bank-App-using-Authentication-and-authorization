using System.Security.Claims;
using Bank_App.Models;
using Bank_App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank_App.Controllers
{
    public class CEOController : Controller
    {

          private readonly ICEOService _service;

        public CEOController(ICEOService service)
        {
            _service = service;
        }
        
        //  [Authorize(Roles = "CEO")] 
        [HttpGet]
        public IActionResult IndexCEOPage()
        {
            return View();
        }
         [Authorize(Roles = "CEO,User")] 
          public IActionResult ManageManagers()
        {
            return View();
        }
        // [Authorize(Roles = "CEO")] 
        public IActionResult CreateCEO()
        {
            return View();
        }
        //  [Authorize] 
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult CreateCEO(CEO ceo)
        {
            if(ceo != null)
            { 
                _service.CreateCEO(ceo);
                TempData["success"] = "Manager Created Successfully";
                return RedirectToAction(nameof(IndexCEOPage));
            }
            else
            {
                ViewBag.Error = "Wrong Input";
               return View();
            }
        }

        //  [Authorize(Roles = "CEO")] 
       
         public IActionResult DeleteCEO(string ceoId)
        {            
            var ceo = _service.GetCEOById(ceoId);
            return View(ceo);          
        }
        [Authorize] 
        [HttpPost , ActionName("DeleteCEO")]
        [ValidateAntiForgeryToken]
         public IActionResult DeleteCEOConfirmed(string ceoId)
        {
            _service.DeleteCEO(ceoId);
            return RedirectToAction(nameof(CEOs));
        }
         [Authorize(Roles = "CEO,User")] 
          [HttpGet]
         public IActionResult UpdateCEO(string ceoId)
        {       
            if(ceoId == null)
            {
                return NotFound();
            }
            var ceo = _service.GetCEOById(ceoId);
            if(ceo == null)
            {
                return NotFound();
            }
            return View(ceo);
        }
         [Authorize] 
        [HttpPost , ActionName("UpdateCEO")]
        [ValidateAntiForgeryToken]
         public IActionResult UpdateCEO(CEO ceo)
        {
            _service.UpdateCEO(ceo);
            return RedirectToAction(nameof(CEOs));
        }


         public IActionResult LogInCEO()
        {
           return View();
           
        }

        [HttpPost , ActionName("LogInCEO")]
         public IActionResult LogInConfirmed(string email,string passWord)
        {
            if(email == null || passWord == null)
            {
                return NotFound();
            }
            var ceo = _service.Login(email,passWord);
            if (ceo == null)
            {
                //  ViewBag.Error = "Invalid Email or PassWord";
                return NotFound();
            }
            // else
            // {
            // return RedirectToAction(nameof(ManageManagers));
            // }

        //     //session

        //      HttpContext.Session.SetString("Email", manager.Email);
        //    HttpContext.Session.SetString("PassWord", manager.PassWord);
        //    return RedirectToAction(nameof(ManageManagers));


          //cookies

               var roles = new List<string>();
              var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , ceo.LastName + " " +ceo.FirstName),
                //new Claim(ClaimTypes.Name , lecturer.LastName + " " +lecturer.FirstName),
                new Claim(ClaimTypes.Email , ceo.Email),
                new Claim(ClaimTypes.Role , "CEO"),
                // new Claim(ClaimTypes.NameIdentifier , 2.ToString()),
                new Claim(ClaimTypes.NameIdentifier , ceo.CEOId)
        
            };

            var claimsIdentity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal, authenticationProperties);

            // foreach(var item in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role , item));
            // }
            return RedirectToAction(nameof(ManageManagers));
           
            
        }

         [Authorize(Roles = "CEO,User")] 
        
         public IActionResult CEOs()
        {
            var ceos = _service.GetAllCEO();
            return View(ceos);
        }

          [Authorize(Roles = "CEO,User")] 
         public IActionResult CEODetails(string ceoId)
        {       
            
            var ceo = _service.GetCEOById(ceoId);
            return View(ceo);
        }
        
    }
}