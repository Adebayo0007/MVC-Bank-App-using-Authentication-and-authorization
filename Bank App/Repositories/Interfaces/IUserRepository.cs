using Bank_App.Models;
using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User UpdateUser(User user);
       User DeleteUser(User user);
        User CreateUser(User user);
        User Login(string email,string passWord);
        User GetUserById(int id);
       IList<User> GetAllUser(); 

    }
}