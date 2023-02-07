using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Manager CreateManager(Manager manager);
        Manager UpdateManager(Manager manager);
        Manager DeleteManager(Manager manager);
       Manager Login(string email, string passWord);
        Manager Code(int code);
       Manager GetManagerById(string managerId);
       IList<Manager> GetAllManager(); 
       string NumberOfManager();
    //    IList<Admin>   ManagerAdmins();
      Manager GetManagerByEmail(string email);
    }
}