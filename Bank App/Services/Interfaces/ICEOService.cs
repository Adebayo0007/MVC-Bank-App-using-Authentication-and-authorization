using Bank_App.Models;

namespace Bank_App.Services.Interfaces
{
    public interface ICEOService
    {
       CEO CreateCEO(CEO ceo);
       CEO UpdateCEO(CEO ceo);
       void DeleteCEOUsingId(string ceoId);
       CEO Login(string email, string passWord);
       CEO GetCEOById(string ceoId);
       IList<CEO> GetAllCEO(); 
    }
}