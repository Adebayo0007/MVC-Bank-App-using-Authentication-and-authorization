using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IManagerService
    {
        Manager CreateManager (ManagerDTO manager);
       void UpdateManager (ManagerRequestModel manager);
       Manager DeleteManager(string managerId);
       Manager Login (string email, string passWord);
       ManagerRequestModel GetManagerById(string managerId);
       IList<Manager> GetAllManager();
         
    }
}