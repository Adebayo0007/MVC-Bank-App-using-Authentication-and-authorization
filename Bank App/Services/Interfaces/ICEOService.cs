
using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ICEOService
    {
       CEO CreateCEO(CEO ceo);
       CEO UpdateCEO(CEO ceo);
       CEO DeleteCEO(string ceoId);
       CEO GetCEOById(string ceoId);
       IList<CEO> GetAllCEO(); 
    }
}