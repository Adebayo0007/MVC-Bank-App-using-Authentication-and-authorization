using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IManagerService
    {
        Manager CreateManager (Manager manager);
       Manager UpdateManager (Manager manager);
       Manager DeleteManager(string managerId);
       Manager Login (string email, string passWord);
       Manager GetManagerById(string managerId);
       IList<Manager> GetAllManager();
         
    }
}