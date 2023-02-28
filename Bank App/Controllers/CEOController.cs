using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Controllers
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
         [Authorize(Roles = "CEO")] 
          public IActionResult ManageManagers()
        {
            return View();
        }
         [Authorize(Roles = "CEO")] 
          public IActionResult AllUsers()
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
                TempData["success"] = "CEO Created Successfully";
                return RedirectToAction("LogIn", "Home");
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
         [Authorize(Roles = "CEO")] 
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

         [Authorize(Roles = "CEO")] 
        
         public IActionResult CEOs()
        {
            var ceos = _service.GetAllCEO();
            return View(ceos);
        }

          [Authorize(Roles = "CEO")] 
         public IActionResult CEODetails(string ceoId)
        {       
            
            var ceo = _service.GetCEOById(ceoId);
            return View(ceo);
        }
        
    }
}