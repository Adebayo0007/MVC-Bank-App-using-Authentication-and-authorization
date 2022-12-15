using MVC_MobileBankApp.Models;

namespace Bank_App.Services.Interfaces
{
    public interface IManagerService
    {
        Manager CreateManager (Manager manager);
       Manager UpdateManager (Manager manager);
       void DeleteManagerUsingId(string managerId);
       Manager Login (string email, string passWord);
       Manager GetManagerById(string managerId);
       IList<Manager> GetAllManager();
         
    }
}