using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IManagerService
    {
        ManagerDTO CreateManager (ManagerDTO manager);
       void UpdateManager (ManagerRequestModel manager);
       ManagerRequestModel DeleteManager(string managerId);
       Manager Login (string email, string passWord);
       Manager Code(int code);
       ManagerRequestModel GetManagerById(string managerId);
       IList<Manager> GetAllManager();
        string NumberOfManager();
        Manager  GetManagerByEmail(string email);
         
    }
}