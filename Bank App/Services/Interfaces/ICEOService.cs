
using Bank_App.Models.DTOs.CEODto;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs.CEODto;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ICEOService
    {
       CreateCeoRequestModel CreateCEO(CreateCeoRequestModel ceo);
    //    CEO UpdateCEO(CEO ceo);
    //    CEO DeleteCEO(string ceoId);
    //    CEO GetCEOById(string ceoId);
    //    IList<CEO> GetAllCEO(); 
    }
}