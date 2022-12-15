using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Manager CreateManager(Manager manager);
        Manager UpdateManager(Manager manager);
       void DeleteManagerUsingId(Manager managerId);
       Manager Login(string email, string passWord);
       Manager GetManagerById(string managerId);
       IList<Manager> GetAllManager(); 
    }
}