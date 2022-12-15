using Bank_App.Models;
using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User UpdateUser(User user);
       void DeleteUserUsingEmail(User user);
        User CreateUser(User user);
        User Login(string email,string passWord);
        User GetUserByEmail(string email);
       IList<User> GetAllUser(); 

    }
}