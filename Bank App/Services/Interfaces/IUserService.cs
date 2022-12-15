using Bank_App.Models;
using MVC_MobileBankApp.Models;

namespace Bank_App.Services.Interfaces
{
    public interface IUserService
    {
        User UpdateUser(User user);
       void DeleteUserUsingEmail(User user);
        User CreateUser(User user);
        User Login(string email,string passWord);
       IList<User> GetAllUser(); 
    }
}