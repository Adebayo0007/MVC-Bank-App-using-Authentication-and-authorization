using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Services.Interfaces
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