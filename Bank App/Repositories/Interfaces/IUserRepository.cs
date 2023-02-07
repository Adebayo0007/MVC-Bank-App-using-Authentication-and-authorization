using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User UpdateUser(User user);
       User DeleteUser(User user);
        User CreateUser(User user);
        User Login(string email,string passWord);
        User GetUserById(int id);
        User GetUserByEmail(string email);
       IList<User> GetAllUser(); 
       string NumberOfUsers();

    }
}