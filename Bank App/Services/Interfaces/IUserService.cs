using Bank_App.Models;
using MVC_MobileBankApp.Models;

namespace Bank_App.Services.Interfaces
{
    public interface IUserService
    {
        User UpdateUser(User user,int userId);
       User DeleteUserUsingId(int userId);
        User CreateUser(User user);
        User Login(string email,string passWord);
       IList<User> GetAllUser(); 
    }
}